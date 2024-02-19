// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function previewImage(event, querySelector) {

	//Recuperamos el input que desencadeno la acción
	const input = event.target;

	//Recuperamos la etiqueta img donde cargaremos la imagen
	$imgPreview = document.querySelector(querySelector);

	// Verificamos si existe una imagen seleccionada
	if (!input.files.length) return

	//Recuperamos el archivo subido
	file = input.files[0];

	//Creamos la url
	objectURL = URL.createObjectURL(file);

	//Modificamos el atributo src de la etiqueta img
	$imgPreview.src = objectURL;

}


//method for select2
$("#dropdownSelector").select2({
	theme: "bootstrap"
});