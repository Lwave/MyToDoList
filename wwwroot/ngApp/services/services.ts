namespace MyToDoList.Services {
    export class OpenModalService {
        constructor(public $uibModal: ng.ui.bootstrap.IModalService) { }
        public openModal(html, todolist = 0) {
            console.log(2);
            this.$uibModal.open({
                templateUrl: `/ngApp/views/${html}`,
                controller: MyToDoList.Controllers.ProfileController,
                controllerAs: "modal",
                resolve: {
                    todolist: () => todolist,
                    
                },
                size: 'md'
            })
        }
    }

    angular.module('MyToDoList').service("OpenModalService", OpenModalService);
}
