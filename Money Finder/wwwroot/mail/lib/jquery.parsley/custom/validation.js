// Custom validators for Parsley

window.Parsley.addValidator('presentinlist', {
    requirementType: 'string',
    validateString: function(value, requirement) {
        return -1 === requirement.split(',').indexOf(value, 0);
    },
    messages: {
        en: 'This List ID already exists in the system.'
    }
});

window.Parsley.addValidator('presentinusers', {
    requirementType: 'string',
    validateString: function(value, requirement) {
        return -1 === requirement.split(',').indexOf(value.toLowerCase(), 0);
    },
    messages: {
        en: 'A user with this email address already exists.'
    }
});

window.Parsley.addValidator('presentinaffiliates', {
    requirementType: 'string',
    validateString: function(value, requirement) {
        return -1 === requirement.split(',').indexOf(value.toLowerCase(), 0);
    },
    messages: {
        en: 'An affiliate with this ID already exists.'
    }
});

window.Parsley.addValidator('presentincontacts', {
    requirementType: 'string',
    validateString: function(value, requirement) {
        return -1 === requirement.split(',').indexOf(value.toLowerCase(), 0);
    },
    messages: {
        en: 'A contact with this email address already exists.'
    }
});