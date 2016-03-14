$(function () {
	// show or hide messagebox
	var messageSettings = $('#hfMessage').val();
	if (messageSettings !== '') {
		var split = messageSettings.split('|');
		var cssClass = split.length > 1 ? split[0] : 'messageError';
		var message = split.length > 1 ? split[1] : split[0];

		showMessage(cssClass, message);
	}

	// messagebox close-button handler
	$('#divMessage .button').click(function () {
		$('.messagebox').hide();
	});
});

function showMessage(cssClass, message) {
	$('#divMessage').addClass(cssClass);
	$('#divMessage span').html(message);
	$('.messagebox').show();
}