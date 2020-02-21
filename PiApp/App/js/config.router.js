'use-strict';

angular.module('app')
  .config(
    function ($stateProvider, $urlRouterProvider){
        $urlRouterProvider.otherwise('/app/food/index');

        $stateProvider
            // HOME STATES AND NESTED VIEWS ========================================
            .state('app', {
                abstract: true,
                url: '/app',
                templateUrl: '/home/app'   //layout
            })

            // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
            .state('app.food', {
                abstract: true,
                url: '/food',
                template: '<div ui-view></div>',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load('/App/controller/foodCtrl.js'); // Resolve promise and load before view 
                    }]
                }
            })
            .state('app.food.index', {
                url: '/index',
                templateUrl: '/home/listfood'
            })
            .state('app.food.create', {
                url: '/create',
                templateUrl: '/home/createfood'
            })
            .state('app.category', {
                abstract: true,
                url: '/category',
                template: '<div ui-view></div>',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load('/App/controller/categoryCtrl.js'); // Resolve promise and load before view 
                    }]
                }
            })
            .state('app.category.index', {
                url: '/index',
                templateUrl: '/category/index'
            })
            .state('app.category.create', {
                url: '/create',
                templateUrl: '/category/create'
            })

    });