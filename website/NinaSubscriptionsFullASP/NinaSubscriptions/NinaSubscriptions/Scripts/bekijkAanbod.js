$(function () {

	/* FADE DISABLED BUTTONS --------------------------------------------------- */
	$('.button').each(function () {
		if ($(this).attr('disabled') == 'disabled') {
			$(this).fadeTo(0, 0.3);
		};
	});

});