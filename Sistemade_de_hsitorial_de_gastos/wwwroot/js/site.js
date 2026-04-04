// ===== JavaScript - Sistema de Historial de Gastos =====

// Confirmación antes de eliminar un gasto
document.addEventListener("DOMContentLoaded", function () {

    // Confirmar eliminación en el botón del formulario de Delete
    var deleteForm = document.querySelector('form[action*="Delete"]');
    if (deleteForm) {
        deleteForm.addEventListener("submit", function (e) {
            var confirmado = confirm("¿Estás seguro de que deseas eliminar este gasto? Esta acción no se puede deshacer.");
            if (!confirmado) {
                e.preventDefault();
            }
        });
    }

    // Resaltar la fila de la tabla al pasar el mouse
    var filas = document.querySelectorAll(".table-gastos tbody tr");
    filas.forEach(function (fila) {
        fila.addEventListener("mouseenter", function () {
            this.style.cursor = "pointer";
        });
    });

    // Formato automático del campo Monto (solo números y punto decimal)
    var campoMonto = document.querySelector('input[name="Monto"]');
    if (campoMonto) {
        campoMonto.addEventListener("input", function () {
            this.value = this.value.replace(/[^0-9.]/g, "");
        });
    }
});