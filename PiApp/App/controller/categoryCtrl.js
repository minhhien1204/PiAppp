'use-strict';

angular.module('app')
    .controller('CategoryCtrl', ['$scope', '$state', '$http', function ($scope, $state, $http) {
        console.log('CategoryCtrl loaded! ! ! !');
        var _url = "/odata/Category";
        var vm = this;
        //var wnd, detailsTemplate;
        vm.model = {};  

        vm.toolbarTemplate = toolbarTemplate;
        vm.create = create;
        vm.submit = submit;

        function submit() {
            //alert(JSON.stringify(vm.model));
            $http({
                method: 'POST',
                url: _url,
                data: JSON.stringify(vm.model),
                headers: {
                    'datatype': "JSON",
                    'contenttype': "application/json"
                }
            })
                .success(function () {
                    $state.go('app.category.index');
                })
                .error(function (data) {
                    console.log('error ' + data);
                });
        }
        function create() {
            $state.go('app.category.create');
        }

        function toolbarTemplate() {
            return kendo.template($("#toolbar").html());
        }

        $scope.mainGridOptions = {
            dataSource: {
                type: "odata-v4",
                transport: {
                    read: _url,
                    update: {
                        url: function (data) {
                            return _url + '(' + data.Id + ')';
                        }
                    },
                    destroy: {
                        url: function (data) {
                            return _url + '(' + data.Id + ')';  //delete
                        }
                    }
                },

                pageSize: 15,
                serverPaging: true,
                serverSorting: true,

                schema: {
                    model: {
                        id: "Id",
                        fields: {
                            Id: { editable: false, nullable: true },
                            Name: { validation: { required: true } }
                        }
                    }
                }
            },
            sortable: true,
            pageable: true,
            height: 700,
            dataBound: function () {
                this.expandRow(this.tbody.find("tr.k-master-row").first());
            },
            columns: [
                {
                    field: "Id",
                    title: "Id",
                    width: "25px"
                },
                {
                    field: "Name",
                    title: "Name of Category",
                    width: "50px"
                },
               
                { command: ["edit", "destroy"], title: "&nbsp;", width: "100px" }],
            editable: "inline"
        };
    }]);