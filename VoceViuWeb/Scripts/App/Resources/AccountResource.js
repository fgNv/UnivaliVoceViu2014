app.factory("AccountResource", function ($resource) {
    return $resource("/api/account/:action/:id", {}, {
        createNewAdvertiser: {
            method: "POST",
            isArray: false,
            params: { 'action': 'CreateNewAdvertiser' }
        },
        authenticateAdvertiser: {
            method: "POST",
            isArray: false,
            params: { 'action': 'AuthenticateAdvertiser' }
        }
    });
});