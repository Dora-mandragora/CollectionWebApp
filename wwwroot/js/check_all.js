
var checkAll = document.getElementById('check_all');
var checkboxes = document.querySelectorAll('input[type = "checkbox"]');

checkAll.addEventListener('change', function(e) {
	var isChecked = this.checked;
  
  for (var i = 0; i < checkboxes.length; i++) {
  	checkboxes[i].checked = isChecked;
  }
  
});