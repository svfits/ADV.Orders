function viewModel() {
    this.authorName = ko.observable('Steve Smith');
    this.twitterAlias = ko.observable('@ardalis');

    this.twitterUrl = ko.computed(function () {
        return "https://twitter.com/" + this.twitterAlias().replace('@', '');
    }, this);

    this.capitalizeTwitterAlias = function () {
        var currentValue = this.twitterAlias();
        this.twitterAlias(currentValue.toUpperCase());
    }
};
ko.applyBindings(viewModel);
