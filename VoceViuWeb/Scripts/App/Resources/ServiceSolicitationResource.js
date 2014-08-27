app.factory("ServiceSolicitationResource", function ($resource) {
    return $resource("/api/serviceSolicitation/:action/:id", {}, {
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
        getPendingApproval: {
            method: "GET",
            isArray: true,
            params: { 'action': 'getPendingApproval' }
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
        getAvailableMonths: {
            method: "GET",
            isArray: true,
            params: { 'action': 'GetAvailableMonths' }
        },
        approve: {
            method: "POST",
            isArray: false,
            params: { 'action': 'Approve' }
        },
        deny: {
            method: "POST",
            isArray: false,
            params: { 'action': 'Deny' }
        }
    });
});