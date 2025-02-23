// Genererat av chatgpt



// Populera dropdowns när sidan har laddats
document.addEventListener("DOMContentLoaded", function () {
  // Fyll på dropdowns med data
  populateDropdown(
    "statusId",
    `${baseApiUrl}/statustype`,
    "statusTypeId",
    "statusName"
  );
  populateDropdown("userId", `${baseApiUrl}/user`, "userId", "firstName");
  populateDropdown(
    "serviceId",
    `${baseApiUrl}/service`,
    "serviceId",
    "serviceName"
  );
  populateDropdown(
    "customerId",
    `${baseApiUrl}/customer`,
    "customerId",
    "customerName"
  );
});

const baseApiUrl = "https://localhost:7288/api";

const handleSubmit = async (event) => {
  event.preventDefault();

  // Hämta dropdown-värden
  const statusId = document.getElementById("statusId").value;
  const userId = document.getElementById("userId").value;
  const serviceId = document.getElementById("serviceId").value;
  const customerId = document.getElementById("customerId").value;
  const totalPrice = document.getElementById("totalPrice").value;

  console.log("Project values:");
  console.log("statusId:", statusId);
  console.log("userId:", userId);
  console.log("serviceId:", serviceId);
  console.log("customerId:", customerId);
  console.log("totalPrice:", totalPrice);

  // Validering: Kontrollera att alla fält har värden innan vi skickar requesten
  if (!statusId || !userId || !serviceId || !customerId || !totalPrice) {
    console.error("Ett eller flera fält är tomma! Avbryter.");
    return;
  }

  // Skapa DTO
  const ProjectDto = {
    projectNumber: event.target["projectNumber"].value,
    title: event.target["title"].value,
    description: event.target["description"].value,
    startDate: event.target["startDate"].value,
    endDate: event.target["endDate"].value,
    totalPrice: parseFloat(totalPrice),
    statusId: parseInt(statusId),
    userId: parseInt(userId),
    serviceId: parseInt(serviceId),
    customerId: parseInt(customerId),
  };

  console.log("ProjectDto to send:", ProjectDto);

  // Skicka request
  try {
    const res = await fetch(`${baseApiUrl}/project`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(ProjectDto),
    });

    const data = await res.json();

    if (!res.ok) {
      console.error("Fel vid spara projekt:", data);
    } else {
      console.log("Projekt skapat:", data);
    }
  } catch (error) {
    console.error("Nätverksfel:", error);
  }
};

// Funktion för att populera en dropdown med data från API
async function populateDropdown(dropdownId, apiUrl, valueField, textField) {
  try {
    const res = await fetch(apiUrl);
    const data = await res.json();

    console.log(`Data från API för ${dropdownId}:`, data); // Logga API-svaret

    if (res.ok) {
      const dropdown = document.getElementById(dropdownId);
      dropdown.innerHTML = "";

      const defaultOption = document.createElement("option");
      defaultOption.textContent = "Välj alternativ";
      defaultOption.value = "";
      dropdown.appendChild(defaultOption);

      data.forEach((item) => {
        console.log(`Adding option to ${dropdownId}:`, item); // Logga varje objekt

        const option = document.createElement("option");
        option.value = item[valueField];
        option.textContent = item[textField];

        if (option.value === undefined) {
          console.warn(
            `⚠️ Värdet för ${dropdownId} är undefined. Kontrollera API-svaret.`
          );
        }

        dropdown.appendChild(option);
      });

      console.log(`Dropdown ${dropdownId} populated successfully!`);
    } else {
      console.error("Fel vid hämtning av data:", data);
    }
  } catch (error) {
    console.error("API-fel:", error);
  }
}




document.querySelector("form").addEventListener("submit", handleSubmit);
