
$(document).ready(function () {

	$('#book-container').click(function () {
		$.ajax({
			data: {
				bookId: $('#bookId-element').val()
			},
			type: 'POST',
			url: '/GetCheckoutInfo'
		})
			.done(function (data) {
				if (data) {
					for (let i = 0; i < data.Checkouts.length && i < 3; i++)
						$(`#book-origin${i}`).text(data.Checkouts[i].UserName);
				}
			});

	});

});