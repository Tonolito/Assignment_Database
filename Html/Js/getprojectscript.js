const apiUrl = "https://localhost:7288/api/project";

// 🔹 Hämta alla projekt och fyll dropdown
async function fetchProjects() {
  try {
    const response = await fetch(apiUrl);
    const projects = await response.json();

    const select = document.getElementById("projectSelect");
    select.innerHTML = '<option value="">Välj...</option>'; // Rensa dropdown

    projects.forEach((project) => {
      let option = document.createElement("option");
      option.value = project.projectId; // Använd projektets ID
      option.textContent = project.title;
      select.appendChild(option);
    });
  } catch (error) {
    console.error("Kunde inte hämta projekt:", error);
  }
}

// 🔹 Hämta statusar, användare, tjänster & kunder och fyll dropdowns
async function fetchDropdownData() {
  try {
    await populateDropdown(
      "statusId",
      "https://localhost:7288/api/statusType",
      "statusTypeId",
      "statusName"
    );
    await populateDropdown(
      "userId",
      "https://localhost:7288/api/User",
      "userId",
      "firstName"
    );
    await populateDropdown(
      "serviceId",
      "https://localhost:7288/api/Service",
      "serviceId",
      "serviceName"
    );
    await populateDropdown(
      "customerId",
      "https://localhost:7288/api/Customer",
      "customerId",
      "customerName"
    );
  } catch (error) {
    console.error("Kunde inte hämta dropdown-data:", error);
  }
}

// 🔹 Funktion för att fylla dropdown
async function populateDropdown(elementId, url, valueKey, textKey) {
  try {
    const response = await fetch(url);
    const data = await response.json();

    const select = document.getElementById(elementId);
    select.innerHTML = '<option value="">Välj...</option>'; // Rensa dropdown

    data.forEach((item) => {
      let option = document.createElement("option");
      option.value = item[valueKey]; // ID som värde
      option.textContent = item[textKey]; // Namn som text
      select.appendChild(option);
    });
  } catch (error) {
    console.error(`Kunde inte ladda ${elementId}:`, error);
  }
}

// 🔹 Ladda vald projekts data i input-fälten
async function loadProjectDetails() {
  const projectId = document.getElementById("projectSelect").value;
  if (!projectId) {
    alert("Välj ett projekt att redigera!");
    return;
  }

  try {
    const response = await fetch(`${apiUrl}/${projectId}`);
    const project = await response.json();

    if (project) {
      document.getElementById("title").value = project.title;
      document.getElementById("projectNumber").value = project.projectNumber;
      document.getElementById("description").value = project.description;
      document.getElementById("startDate").value =
        project.startDate.split("T")[0];
      document.getElementById("endDate").value = project.endDate.split("T")[0];
      document.getElementById("totalPrice").value = project.totalPrice;

      // Sätt dropdowns till korrekta ID:n
      document.getElementById("statusId").value = project.statusId;
      document.getElementById("userId").value = project.userId;
      document.getElementById("serviceId").value = project.serviceId;
      document.getElementById("customerId").value = project.customerId;
    } else {
      alert("Projektet hittades inte.");
    }
  } catch (error) {
    console.error("Kunde inte ladda projekt:", error);
  }
}

// 🔹 Uppdatera projekt
async function updateProject() {
  const projectId = document.getElementById("projectSelect").value;
  if (!projectId) {
    alert("Välj ett projekt att uppdatera!");
    return;
  }

  const updatedData = {
    Id: parseInt(projectId),
    projectNumber: document.getElementById("projectNumber").value,
    title: document.getElementById("title").value,
    description: document.getElementById("description").value,
    startDate: new Date(
      document.getElementById("startDate").value
    ).toISOString(),
    endDate: new Date(document.getElementById("endDate").value).toISOString(),
    totalPrice: parseFloat(document.getElementById("totalPrice").value),
    statusId: parseInt(document.getElementById("statusId").value),
    userId: parseInt(document.getElementById("userId").value),
    serviceId: parseInt(document.getElementById("serviceId").value),
    customerId: parseInt(document.getElementById("customerId").value),
  };

  try {
    const response = await fetch(`${apiUrl}/${projectId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(updatedData),
    });
    console.log("Uppdaterad data:", JSON.stringify(updatedData, null, 2));
    if (response.ok) {
      alert("Projekt uppdaterat!");
    } else {
      alert("Misslyckades att uppdatera projektet.");
    }
  } catch (error) {
    console.error("Fel vid uppdatering:", error);
  }
}

// 🔹 Ladda data vid start
fetchProjects();
fetchDropdownData();
