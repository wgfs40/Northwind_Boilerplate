(function () {
    $(function () {

        var _$rolesTable = $('#RolesTable');
        var _roleService = abp.services.app.role;


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Roles/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Views/Roles/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditRoleModal'
        });



        _$rolesTable.jtable({
            title: 'Role list',
            paging: true, //Enable paging
            pageSize: 10, //Set page size (default: 10)
            sorting: true, //Enable sorting
            defaultSorting: 'Order Date DESC', //Set default sorting
            actions: {
                listAction: {
                    method: _roleService.getRolesLists
                },
                createAction: '/Actions/CreateOrder',
                updateAction: '/Actions/UpdateOrder',
                deleteAction: '/Actions/DeleteOrder'
            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: 'Actions',
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $('<button class="btn btn-default btn-xs" title="' + 'Edit' + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                _createOrEditModal.open({ id: data.record.id });
                            });


                        return $span;
                        }
                    },
                displayName: {
                    title: 'Display name',
                    width: '40%',
                    list: true
                },
                isstatic: {
                    title: 'Is Static',
                    width: '15%',
                    type: 'checkbox',
                    values: { 'false': 'Passive', 'true': 'Active' },
                    defaultValue: 'true',
                    list: true
                },
                isdefault: {
                    title: 'Is Default',
                    width: '15%',
                    type: 'checkbox',
                    values: { 'false': 'Passive', 'true': 'Active' },
                    list: true
                },
                creationtime: {
                    title: 'Name',
                    width: '40%',
                    list: true
                }

            }
        });//end jtable


        $("#CreateNewRoleButton").click(function () {
            _createOrEditModal.open();
        });

        function getUsers(reload) {
            if (reload) {
                _$rolesTable.jtable('reload');
            } else {
                _$rolesTable.jtable('load', {
                    filter: $('#UsersTableFilter').val(),
                    permission: $("#PermissionSelectionCombo").val(),
                    role: $("#RoleSelectionCombo").val()
                });
            }
        }

        abp.event.on('app.createOrEditRoleModalSaved', function () {
            getUsers();
        });

        getUsers();
        //$('#UsersTableFilter').focus();

    });
})();
