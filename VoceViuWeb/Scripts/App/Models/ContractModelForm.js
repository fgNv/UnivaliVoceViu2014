var ContractModelForm = function (contractModel) {
    contractModel = contractModel || {};

    this.Id = contractModel.Id || null;
    this.Summary = contractModel.Summary || '';
    this.Terms = contractModel.Terms || '';
    this.Name = contractModel.Name || '';

    var self = this;

    this.Validate = function () {
        var errors = [];

        if (!self.Summary)
            errors.push("Deve-se fornecer um sumário");
        if (!self.Summary)
            errors.push("Deve-se fornecer as cláusulas");
        if (!self.Name)
            errors.push("Deve-se fornecer o nome");

        return errors;
    };
};