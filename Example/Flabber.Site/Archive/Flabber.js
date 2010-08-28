function FlabberManager(settings)
{	
	var _currentDate;
	var _settings = settings;
	this.init = init;

	function init()
	{		
		// Autcomplete data source
		$("#input-description").autocomplete(_settings.autocompleteUrl).result(
		function(event, item) {
			$.getJSON(_settings.getItemCaloriesUrl, { title: $("#input-description").val() },
				function(data) {
					$("#input-calories").val(data.calories);
				}
			);

			$("#button-add").focus();
		});
		
		// Configure the datepicker
		$("#datepicker-container").datepicker(
		{
			onSelect : datePickerSelect,
			showButtonPanel : true,
			dateFormat : _settings.dateFormat
		});
		
		// Datepicker link click
		$("#link-datepicker").click(function()
		{ 
			$("#datepicker-container").toggle();
			$("#dialog-add").fadeOut();
		});

		// Show the add dialog
		$("#link-add").click(function() {
			$("#datepicker-container").hide();

			$("#input-description").val("");
			$("#input-calories").val("");

			setTimeout('$("#input-description").focus()',20);
			$("#dialog-add").toggle();
			return false;
		});
		
		// Dialog close
		$("#dialog-add .close a").click(function() {
			$("#dialog-add").fadeOut();
			return false;
		});		
		
		bindAddLink();
		_currentDate = new Date().toDateString();
		
		// Show today's list
		updateCalorieTotal();
		updateEntryList();
	}
	
	function datePickerSelect(dateText, inst)
	{
		$("#datepicker-container").fadeOut();
		_currentDate = dateText;
		$("#input-date").val(dateText);
		
		updateCalorieTotal();
		updateEntryList();
	}
	
	function bindAddLink()
	{
		$("#button-add").click(function(){
		
			$.post(_settings.addEntryUrl,
			{
				date: $("#input-date").val(),
				title: $("#input-description").val(),
				calories: parseFloat($("#input-calories").val())
			},
			ajaxComplete);
		});
	}
	
	function bindDeleteLinks()
	{
		// Delete link
		$(".link-delete").click(function()
		{
			var guid = $(this).attr("id");
			
			$.post(_settings.deleteEntryUrl,
			{
				id: guid
			},
			ajaxComplete);
		});
	}
	
	function ajaxComplete(data,textStatus)
	{
		$("#dialog-add").fadeOut();
		
		if (textStatus == "success")
		{
			updateCalorieTotal();
			updateEntryList();
		}
		else
		{
			alert("An error occurred (" +textStatus+ ").");
		}
	}
	
	
	function updateEntryList(date)
	{
		$.get(_settings.getListUrl,
			{ date: _currentDate },
			function(data){			
				$("#calorie-list").html(data);
				bindDeleteLinks();
		});
	}
	
	function updateCalorieTotal(date)
	{
		$.get(_settings.getCalorieTotalUrl,
			{ date: _currentDate },
			function(data){
				$("#calorie-total").html(data);
		});
	}
}