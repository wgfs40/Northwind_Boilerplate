$(function () {
    var _$rolesTable = $('#RolesTable');
    var _roleService = abp.services.app.role;

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
            displayName: {
                title: 'Display name',
                width: '40%',
                list: true
            },
            isstatic:{
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
            name: {
                title: 'Name',
                width: '40%',
                list: true
            }

        }
    });//end jtable


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

    getUsers();
    //$('#UsersTableFilter').focus();

});