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


// KEEP PAGE FROM SCROLLING TO TOP ON POSTBACK -----------------------------------------------------------------------------
// SOURCE: http://www.aspsnippets.com/Articles/ASPNet-MaintainScrollPositionOnPostback-not-working-in-Firefox-and-Chrome.aspx
window.onload = function () {
	var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
	if (!isNaN(scrollY)) {
		window.scrollTo(0, scrollY);
	}
};

window.onscroll = function () {
	var scrollY = document.body.scrollTop;
	if (scrollY == 0) {
		if (window.pageYOffset) {
			scrollY = window.pageYOffset;
		}
		else {
			scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
		}
	}
	if (scrollY > 0) {
		var input = document.getElementById("scrollY");
		if (input == null) {
			input = document.createElement("input");
			input.setAttribute("type", "hidden");
			input.setAttribute("id", "scrollY");
			input.setAttribute("name", "scrollY");
			document.forms[0].appendChild(input);
		}
		input.value = scrollY;
	}
};