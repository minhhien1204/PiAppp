'use strict';

angular.module('app')
    .controller('UpdateCategoryCtrl', ['$scope', '$state', '$http', function ($scope, $state, $http) {
        console.log('UpdateCategoryCtrl loaded!');
        var foodId = $state.params.foodId;   //pass student id from state sapp.student.index

        var _url = "/odata/Category";
        var vm = this;
        vm.toolbarTemplate = toolbarTemplate;


        function toolbarTemplate() {
            return kendo.template($("#toolbar").html());
        }

        $scope.mainGridOptions = {
            dataSource: {
                type: "odata-v4",
                transport: {
                    read: _url,
                },

                pageSize: 15,
                serverPaging: true,
                serverSorting: true
            },
            sortable: true,
            pageable: true,
            height: 600,
            dataBound: function () {
                this.expandRow(this.tbody.find("tr.k-master-row").first());
            },
            columns: [
                {
                    field: "Id",
                    title: "Id Category",
                    width: "20px"
                },
                {
                    field: "Name",
                    title: "Name",
                    width: "50px"
                },

             
                { command: [{ text: "Confirm", click: goregister }], title: "&nbsp;", width: "50px" }
            ],
            editable: "inline"
        };
        function goregister(e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr")); //lay ra data o 1 row
            var model = {};
            model.Id = foodId;
            model.CategoryId = dataItem.Id;

            $http({
                method: 'PUT',
                url: '/odata/Food(' + foodId + ')',
                data: JSON.stringify(model),
                headers: {
                    'datatype': "JSON",
                    'contenttype': "application/json"
                }
            })
                .success(function (data) {
                    $state.go('app.food.index');


                })
                .error(function (data) {
                    console.log('error ' + data);
                });
        }
    }]);