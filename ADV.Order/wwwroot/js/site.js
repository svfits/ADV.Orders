function viewModel() {
    this.authorName = ko.observable('Steve Smith');
    this.twitterAlias = ko.observable('@ardalis');

    //this.twitterUrl = ko.computed(function () {
    //    console.info("ggggggggggggggggggg1111111111111111");
    //    return "https://twitter.com/" + this.twitterAlias().replace('@', '');
    //}, this);

    this.capitalizeTwitterAlias = function () {

        var currentValue = this.twitterAlias();
        console.info("ggggggggggggggggggg222222222222222222222 " + event.target.id);
        this.twitterAlias(currentValue.toUpperCase());

    }
};
ko.applyBindings(viewModel);
