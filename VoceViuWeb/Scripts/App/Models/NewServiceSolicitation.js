var NewServiceSolicitation = function () {
    this.LocationId = null;
    this.StartMonth = ''; 
    this.MonthQuantity = 0;
    this.ContractModelId = 0;

    var self = this;

    this.Validate = function () {
        var errors = [];

        if (!self.LocationId)
            errors.push("Deve-se definir uma localidade");

        if (!self.MonthQuantity)
            errors.push("Deve-se definir uma quantidade de meses");

        if (!self.StartMonth)
            errors.push("Deve-se definir o mês de início");

        if (!self.ContractModelId)
            errors.push("Deve-se definir o modelo de contrato");

        return errors;
    };
};
