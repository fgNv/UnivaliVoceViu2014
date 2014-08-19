var NewAccountRequest = function () {
    this.Name = "";
    this.Password = "";
    this.PasswordConfirmation = "";
    this.Email = "";

    var self = this;

    this.Validate = function () {

        var errors = [];

        if (!self.Email)
            errors.push("Deve-se especificar um email");

        if (!self.Name)
            errors.push("Deve-se especificar um nome");

        if (!self.Password)
            errors.push("Deve-se especificar uma senha");

        if (self.Password != self.PasswordConfirmation)
            errors.push("A confirmação da senha não coincide com a senha");

        return errors;
    }
};