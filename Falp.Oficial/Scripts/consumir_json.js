var app = angular.module('MyApp', [])
app.controller('MyController', function ($scope, $http, $window) {
    $scope.ButtonClick = function () {
        var post = $http({
            method: "POST",
            url: "Generar_Pedido.aspx/Sumar",
            dataType: 'json',
            data: { name: $scope.Name },
            headers: { "Content-Type": "application/json" }
        });

        post.success(function (data, status) {
            mensajes();
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }
});