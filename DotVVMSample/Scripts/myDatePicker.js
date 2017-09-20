ko.bindingHandlers["myDatePicker"] = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        $(element)
            .datepicker({ format: "yyyy/mm/dd" })
            .on('changeDate', function (e) {
                // this will retrieve the property from the viewmodel
                var prop = valueAccessor();        
                
                // if the property is ko.observable, we'll set the value
                if (ko.isObservable(prop)) {    
                    prop(e.date);
                }
            })        
            .on('change', function (e) {            
                if (!$(element).val()) {
                    // if someone deletes the value from the textbox, set null to the viewmodel property
                    var prop = valueAccessor();
                    if (ko.isObservable(prop)) {                    
                        prop(null);
                    }
                }
            });
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        // get the value from the viewmodel
        var value = ko.unwrap(valueAccessor());
        
        // if the value in viewmodel is string, convert it to Date
        if (value && typeof value === "string") {
            value = new Date(value);
        }
        
        // set the value to the control
        if (value) {
            $(element).datepicker("setValue", value);
        }
    }
};