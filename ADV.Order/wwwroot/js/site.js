function viewModel() {

    var idOrder = 0;
    //var previousCount = self.datailOrder;

    $.ajax({
        url: "/Home/DatailOrder",
        data: {
            id: idOrder
        },
        type: "GET",
        dataType: "html",
        async: false,
        success: function (data) {
            self.datailOrder = ko.observable(data);
        },
        error: function (data) {
            console.error("Что то произошло не так при получении datailOrder " + data);
        }
    });

    $.ajax({
        url: "/Home/Products",
        data: {
            id: idOrder
        },
        type: "GET",
        dataType: "html",
        async: false,
        success: function (data) {
            self.products = ko.observable(data);
        },
        error: function (data) {
            console.error("Что то произошло не так при получении продуктов " + data);
        }
    });

    this.order = function () {

        var self = this;
        var idOrder = event.target.id;

        $.ajax({
            url: "/Home/DatailOrder",
            data: {
                id: idOrder
            },
            type: "GET",
            dataType: "html",
            async: false,
            success: function (data) {
                self.datailOrder(data);
            },
            error: function (data) {
                console.error("Что то произошло не так при получении datailOrder " + data);
            }
        });

        $.ajax({
            url: "/Home/Products",
            data: {
                id: idOrder
            },
            type: "GET",
            dataType: "html",
            async: false,
            success: function (data) {
                self.products = ko.observable(data);
            },
            error: function (data) {
                console.error("Что то произошло не так при получении продуктов " + data);
            }
        });
    }
};

ko.applyBindings(viewModel);
