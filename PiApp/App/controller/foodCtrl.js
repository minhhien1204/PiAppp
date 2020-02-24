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
       
        function submit() {
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
                    $state.go('app.food.index');
                })
                .error(function (data) {
                    console.log('error ' + data);
                });
        }
       
        function create() {
            $state.go('app.food.create');
        }
        function toolbarTemplate() {
            return kendo.template($("#toolbar").html());
        }
        function goRegister(e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr")); //lay ra data o 1 row

            $state.go('app.food.updateCategoryId', { foodId: dataItem.Id });
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
                            Name: { type:"string",  validation: { required: true } },
                            Price: { type: "number",validation: { required: true, min: 10 } },
                            PricePromotion: { type: "number", validation: { required: false, min: 10 } }
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
                    title: "PricePromotion",
                    width: "80px"
                },
                {
                    field: "NameOfCategory",
                    title: "NameOfCategory",
                    width:"150px"
                },
                { command: ["edit", "destroy", { text: "Update Category", click: goRegister }], title: "&nbsp;", width: "100px" }],
            editable: "inline"
        };
       
    }]);