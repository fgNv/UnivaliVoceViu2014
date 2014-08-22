var LocationForm = function (location) {

    location = location || {};

    this.Name = location.Name || "";
    this.Spot = location.Spot || 0;
    this.IP = location.IP || "";
    this.Points = location.Points || [];
    this.Id = location.Id || null;
    this.MonthlyValue = location.MonthlyValue || 0;

    var self = this;

    this.addPoint = function () {
        self.Points.push(new Point());
    };

    this.removePoint = function (point) {
        self.Points = Enumerable.From(self.Points).Where(function (i) { return i != point }).ToArray();
    };

    this.Validate = function () {
        var errors = [];

        if (!self.Name)
            errors.push("Deve-se fornecer um nome");
        if (!self.IP)
            errors.push("Deve-se fornecer um IP");
        if (!self.MonthlyValue)
            errors.push("Deve-se fornecer um valor mensal");
        if (!self.Spot)
            errors.push("Deve-se fornecer um spot");
        if (self.Points.length == 0)
            errors.push("Deve-se especificar os pontos de exibição");
        else if (Enumerable.From(self.Points).Any(function (i) { return i.Name == ""; }))
            errors.push("Deve-se especificar o nome de todos os pontos de exibição");

        return errors;
    };
};

var Point = function (point) {
    point = point || {};

    this.Name = point.Name || "";
    this.Id = point.Id || null;

    var self = this;
};