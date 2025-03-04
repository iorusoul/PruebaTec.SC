document.getElementById('btn-next').addEventListener('Click', function (currentPage) {

    //const currentPage = @currentPage + 1;
    console.log("next");
    fetch(`/Asignaturas/RefrescarTabla?page=${currentPage}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('tabla-asignaturas').innerHTML = data;
        });
});

document.getElementById('btn-prev').addEventListener('Click', function (currentPage) {

    //const currentPage = @currentPage - 1;
    console.log("prev");
    fetch(`/Asignaturas/RefrescarTabla?page=${currentPage}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('tabla-asignaturas').innerHTML = data;
        });
});
