(function() {
    $(function() {
        var _$usersTable = $('#UsersTable');
        var _userService = abp.services.app.user;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _userService.createUser(user).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });


      _$usersTable.jtable({
            title: 'User list',
            paging: true, //Enable paging
            pageSize: 10, //Set page size (default: 10)
            sorting: true, //Enable sorting
            defaultSorting: 'Order Date DESC', //Set default sorting
            actions: {
                listAction: {
                    method: _userService.userAll
                },
                createAction: '/Actions/CreateOrder',
                updateAction: '/Actions/UpdateOrder',
                deleteAction: '/Actions/DeleteOrder'
            },
            fields: {
                id: {
                    key: true,
                    list:true
                },
                name:{
                    title: 'User name',
                    width: '40%',
                    list: true
                },
                surname: {
                    title: 'SurName',
                    width: '40%',
                    list: true
                }

            }
        });//end jtable

      //_$usersTable.jtable('load');
      
        //[‎6 /‎29 /‎2017 1:44 PM]  Carlos Encarnacion:
        function getUsers(reload) {
            if (reload) {
                _$usersTable.jtable('reload');
            } else {
                 _$usersTable.jtable('load', {
                    filter: $('#UsersTableFilter').val(),
                    permission: $("#PermissionSelectionCombo").val(),
                    role: $("#RoleSelectionCombo").val()
                });
            }
      }
        $('#GetUsersButton, #RefreshUserListButton').click(function (e) {
            e.preventDefault();
            getUsers();
        });

        getUsers();
        $('#UsersTableFilter').focus();
    });
})();