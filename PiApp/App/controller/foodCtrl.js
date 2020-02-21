'use-strict';

angular.module('app')
    .controller('FoodCtrl', ['$scope', '$state', '$http', function ($scope, $state, $http) {
        console.log('FoodCtrl loaded! ! ! !');
        var _url = "/odata/Food";
        var vm = this;
        //var wnd, detailsTemplate;
        vm.model = {};  //data client nhap vao`

        vm.toolbarTemplate = toolbarTemplate;
        vm.create = create;
        vm.submit = submit;
        vm.destroy = destroy;
        function submit() {
            //alert(JSON.stringify(vm.model));
            $http({
                method: 'POST',
                url: '/odata/Students',
                data: JSON.stringify(vm.model),
                headers: {
                    'datatype': "JSON",
                    'contenttype': "application/json"
                }
            })
                .success(function () {
                    $state.go('app.student.index');
                })
                .error(function (data) {
                    console.log('error ' + data);
                });
        }
        function destroy() {
            //alert(JSON.stringify(vm.model));
            var grid = $('#staffgrid').data('kendoGrid');
            var selectedItem = grid.dataItem(grid.select());
            //alert(selectedItem.Id);
            $http({
                method: 'DELETE',
                url: _url + '(' + selectedItem.Id + ')'
            })
                .success(function () {
                    $('#staffgrid').data('kendoGrid').dataSource.read();
                    $('#staffgrid').data('kendoGrid').refresh();
                    //toaster.pop('success', 'Delete successfully');
                })
        }
        function create() {
            $state.go('app.food');
        }
        function goRegister(e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr")); //lay ra data o 1 row

            $state.go('app.student.register', { studentId: dataItem.Id });
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
                            Name: { validation: { required: true } },
                            Address: {
                                type: "string", validation: { required: true }
                            }
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
                    title: "Name of Food",
                    width: "50px"
                },
                {
                    field: "Price",
                    title: "Price",
                    width: "80px"
                },
                {
                    field: "PricePromotion",
                    title: " PricePromotion",
                    width: "80px"
                },
                { command: ["edit", "destroy", { text: "Register Course", click: goRegister }], title: "&nbsp;", width: "100px" }],
            editable: "inline"
        };
    }]);