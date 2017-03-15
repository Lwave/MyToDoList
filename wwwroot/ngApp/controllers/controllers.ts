namespace MyToDoList.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }
    export class ModalController {
        public list;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService,
            public toDoListId, public $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) {
            if (toDoListId) {
                $http.get(`api/toDoLists/${toDoListId}`).then((res) => {
                    this.list = res.data;
                })
            }
        }

        
        public closeModal() {
            this.$uibModalInstance.close();
        }
    }

    export class ProfileController {
        public todoitems;
        public todoitem;
        public todolists;
        public todolist;
        public applicationUser;
        public appUserId;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService, public OpenModalService: MyToDoList.Services.OpenModalService) {

            $http.get('/api/applicationUser/getLoginUser').then((res) => {
                this.applicationUser = res.data;
                console.log(this.applicationUser);
            })
            this.$http.get('api/todoLists').then((res) => {
                this.todolists = res.data;
                console.log(this.todolists);
            })
            this.$http.get('api/todoItems').then((res) => {
                this.todoitems = res.data;
            });
        }
            public openModal(html, toDoListId) {
            this.OpenModalService.openModal(html, toDoListId);
        }
          

        public addToDoItem(todoitem, toDoListId) {
            console.log(todoitem);
            this.$http.post(`api/toDoItems/${toDoListId}/${todoitem}`, null).then((res) => {
                this.$state.reload();
            });
        }

        public deletetoDoItem(id, toDoListId) {
            console.log(id);
            this.$http.delete(`api/toDoItems/${id}`).then((res) => {
                this.$state.reload();
            });
        }
        public addtoDoList(list) {
            console.log(list);
            this.$http.post(`api/toDoLists`, list).then((res) => {
                

            });
        }
        public deletetoDoList(id, lists) {
            console.log(lists);
            this.$http.delete(`api/toDoLists/${id}`).then((res) => {
                this.$state.reload();
            });
        }
       
      
    }
    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
    //    public todoitems;
        //    public alltodoItems;
        //    public ToDoItemResource;
        //    public todolists;
        //    public alltodoLists;
        //    public ToDoListResource;
        //    public allUsers;
        //    public UserResource;

        //    public getToDoItem() {
        //        this.alltodoItems = this.ToDoItemResource.query();
        //    }
        //    public getToDoList() {
        //        this.alltodoLists = this.ToDoListResource.query();
        //    }
        //    public getUserId() {
        //        this.allUsers = this.UserResource.query();
        //    }


        //    public save() {
        //        this.ToDoItemResource.save(this.todoitems).$promise.then(() => {
        //            this.todoitems = null;
        //            this.getToDoItem();
        //        });
        //    }
        //    constructor(public $resource: angular.resource.IResourceService ) {
        //        this.ToDoItemResource = $resource('/api/toDoItems/:id');
        //        this.getToDoItem();
        //        this.ToDoListResource = $resource('/api/toDoLists/:id');
        //        this.getToDoList();
        //        this.UserResource = $resource('/api/applicationUser/getLoginUser');
        //        this.getUserId();           
        //    }


        //}