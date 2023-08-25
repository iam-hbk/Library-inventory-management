//I saw JQuery installed, so instead of using fecth, I'll just use it with AJAX
function addItem(data) {
    //console.log(data);
    $.ajax({
        url: '/Inventory/Add',
        type: 'POST',
        data: data,
        success: function (response) {
            // Update the UI
            var table = document.getElementById("inventoryTable").getElementsByTagName('tbody')[0];
            var newRow = table.insertRow(table.rows.length);

            var cell1 = newRow.insertCell(0);
            var cell2 = newRow.insertCell(1);
            var cell3 = newRow.insertCell(2);

            cell1.innerHTML = response.name;  // Assuming response contains name
            cell2.innerHTML = response.price; // Assuming response contains price
            cell3.innerHTML = 'Edit | Delete'; // You can add links here
        }
    });
}
