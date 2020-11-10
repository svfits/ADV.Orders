
function viewModel() {

    var self = this;

    var datailOrder = $("#datailOrder").html();
    self.datailOrder = ko.observable(datailOrder);

    var products = $("#products").html();
    self.products = ko.observable(products);

    this.order = function () {

        var self = this;
        var idOrder = event.target.id;

        GetDatailOrder(idOrder, self);

        GetProducts(idOrder, self);
    }

    async function GetDatailOrder(idOrder, self) {
        $.ajax({
            url: "/Home/DatailOrder",
            data: {
                id: idOrder
            },
            type: "GET",
            dataType: "html",
            success: function (data) {
                self.datailOrder(data);
            },
            error: function (data) {
                console.error("Что то произошло не так при получении datailOrder " + data);
            }
        });
    }

    async function GetProducts(idOrder, self) {
        $.ajax({
            url: "/Home/Products",
            data: {
                id: idOrder
            },
            type: "GET",
            dataType: "html",
            success: function (data) {
                self.products(data);
            },
            error: function (data) {
                console.error("Что то произошло не так при получении продуктов " + data);
            }
        });
    }
};

ko.applyBindings(viewModel);
