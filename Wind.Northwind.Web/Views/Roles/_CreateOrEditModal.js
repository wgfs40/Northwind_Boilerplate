(function () {
    $(function () {
        var _modalManager;
        var _roleService = abp.services.app.role;
        var _$roleInformationForm = null;
        var _permissionsTree;


        this.init = function (modalManager) {
            _modalManager = modalManager;

            _permissionsTree = new PermissionsTree();
            _permissionsTree.init(_modalManager.getModal().find('.permission-tree'));

            _$roleInformationForm = _modalManager.getModal().find('form[name=RoleInformationsForm]');
            _$roleInformationForm.validate({ ignore: "" });
        };

        //this.init();

    }); 
})();