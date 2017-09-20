
bindingHandlers["chatSync"] = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        $.connection.chatViewModel.client.broadcastMessage = function (name, message) {
            var encodedName = $("<div />").text(name).html();
            var encodedMsg = $("<div />").text(message).html();
            $("#discussion").append("<li><strong>" + encodedName + "</strong>:&nbsp;&nbsp;" + encodedMsg + "</li>");
        };

        $("#displayname").val(prompt("Enter your name:", ""));
        $("#message").focus();

        $.connection.hub.start().done( () =>{
            $("#sendmessage").click(() => {

                $.connection.chatViewModel.server.send($("#displayname").val(), $("#message").val());
                $("#message").val("").focus();
            });
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
