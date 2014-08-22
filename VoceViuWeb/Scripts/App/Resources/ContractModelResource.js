app.factory("ContractModelResource", function ($resource) {
    return $resource("/api/contractModel/:action/:id", {}, {
        add: {
            method: "POST",
            isArray: false,
            params: { 'action': 'add' }
        },
        update: {
            method: "POST",
            isArray: false,
            params: { 'action': 'update' }
        },
        getAll: {
            method: "GET",
            isArray: true,
            params: { 'action': 'GetAll' }
        },
        get: {
            method: "GET",
            isArray: false,
            params: { 'action': 'Get' }
        },
        remove: {
            method: "POST",
            isArray: false,
            params: { 'action': 'Remove' }
        }
    });
});