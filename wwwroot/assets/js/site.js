document.addEventListener("DOMContentLoaded", function () {
    const darkModeToggle = document.getElementById("darkModeToggle");
    const currentMode = localStorage.getItem("darkMode");
  
    if (currentMode === "enabled") {
      document.body.classList.add("dark-mode");
      darkModeToggle.checked = true;
    }
  
    darkModeToggle.addEventListener("change", function () {
      if (this.checked) {
        document.body.classList.add("dark-mode");
        localStorage.setItem("darkMode", "enabled");
      } else {
        document.body.classList.remove("dark-mode");
        localStorage.setItem("darkMode", "disabled");
      }
    });
  });
  
