/*!
    * Start Bootstrap - SB Admin v7.0.5 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2022 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

        document.querySelectorAll(".delete-btn").forEach(function(btn) {
            btn.addEventListener("click", function () {
                var id = this.getAttribute("data-id");
                if (confirm("Are you sure you want to delete this product?")) {
                    fetch(`/Product/Delete/${id}`, {
                        method: "POST"
                    })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error("Network response was not ok");
                            }
                            // Reload the page after successful deletion
                            location.reload();
                        })
                        .catch(error => {
                            console.error("There was an error!", error);
                        });
                }
            });
        });


window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

        document.getElementById("deleteButton").addEventListener("click", function () {
            if (confirm("Are you sure you want to delete this product?")) {
            document.getElementById("deleteForm").submit();
            }
        });

