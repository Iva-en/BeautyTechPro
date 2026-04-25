const API_URL = "https://localhost:7298/api";

let editingStudentId = null;
let editingInstructorId = null;
let editingModuleId = null;
let editingPracticeId = null;
let editingScheduleId = null;

function showSection(id) {
    document.querySelectorAll(".section").forEach(section => {
        section.classList.remove("active");
    });

    document.getElementById(id).classList.add("active");
}

// STUDENTS
async function loadStudents() {
    const response = await fetch(`${API_URL}/students`);
    const data = await response.json();

    const table = document.getElementById("studentsTable");
    table.innerHTML = "";

    data.forEach(student => {
        table.innerHTML += `
            <tr>
                <td>${student.id}</td>
                <td>${student.name}</td>
                <td>${student.email}</td>
                <td>${student.phone}</td>
                <td>${student.registrationDate?.split("T")[0]}</td>
                <td>
                    <button onclick="editStudent(${student.id}, '${student.name}', '${student.email}', '${student.phone}', '${student.registrationDate?.split("T")[0]}')">Edit</button>
                    <button onclick="deleteStudent(${student.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById("studentForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const student = {
        id: editingStudentId ?? 0,
        name: document.getElementById("studentName").value,
        email: document.getElementById("studentEmail").value,
        phone: document.getElementById("studentPhone").value,
        registrationDate: document.getElementById("studentDate").value
    };

    if (editingStudentId) {
        await fetch(`${API_URL}/students/${editingStudentId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(student)
        });
        editingStudentId = null;
    } else {
        await fetch(`${API_URL}/students`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(student)
        });
    }

    this.reset();
    loadStudents();
});

function editStudent(id, name, email, phone, date) {
    editingStudentId = id;
    document.getElementById("studentName").value = name;
    document.getElementById("studentEmail").value = email;
    document.getElementById("studentPhone").value = phone;
    document.getElementById("studentDate").value = date;
}

async function deleteStudent(id) {
    if (confirm("Delete this student?")) {
        await fetch(`${API_URL}/students/${id}`, { method: "DELETE" });
        loadStudents();
    }
}

// INSTRUCTORS
async function loadInstructors() {
    const response = await fetch(`${API_URL}/instructors`);
    const data = await response.json();

    const table = document.getElementById("instructorsTable");
    table.innerHTML = "";

    data.forEach(instructor => {
        table.innerHTML += `
            <tr>
                <td>${instructor.id}</td>
                <td>${instructor.name}</td>
                <td>${instructor.specialty}</td>
                <td>${instructor.email}</td>
                <td>
                    <button onclick="editInstructor(${instructor.id}, '${instructor.name}', '${instructor.specialty}', '${instructor.email}')">Edit</button>
                    <button onclick="deleteInstructor(${instructor.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById("instructorForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const instructor = {
        id: editingInstructorId ?? 0,
        name: document.getElementById("instructorName").value,
        specialty: document.getElementById("instructorSpecialty").value,
        email: document.getElementById("instructorEmail").value
    };

    if (editingInstructorId) {
        await fetch(`${API_URL}/instructors/${editingInstructorId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(instructor)
        });
        editingInstructorId = null;
    } else {
        await fetch(`${API_URL}/instructors`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(instructor)
        });
    }

    this.reset();
    loadInstructors();
});

function editInstructor(id, name, specialty, email) {
    editingInstructorId = id;
    document.getElementById("instructorName").value = name;
    document.getElementById("instructorSpecialty").value = specialty;
    document.getElementById("instructorEmail").value = email;
}

async function deleteInstructor(id) {
    if (confirm("Delete this instructor?")) {
        await fetch(`${API_URL}/instructors/${id}`, { method: "DELETE" });
        loadInstructors();
    }
}

// MODULES
async function loadModules() {
    const response = await fetch(`${API_URL}/modules`);
    const data = await response.json();

    const table = document.getElementById("modulesTable");
    table.innerHTML = "";

    data.forEach(module => {
        table.innerHTML += `
            <tr>
                <td>${module.id}</td>
                <td>${module.name}</td>
                <td>${module.description}</td>
                <td>${module.duration}</td>
                <td>${module.instructorId}</td>
                <td>
                    <button onclick="editModule(${module.id}, '${module.name}', '${module.description}', ${module.duration}, ${module.instructorId})">Edit</button>
                    <button onclick="deleteModule(${module.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById("moduleForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const module = {
        id: editingModuleId ?? 0,
        name: document.getElementById("moduleName").value,
        description: document.getElementById("moduleDescription").value,
        duration: parseInt(document.getElementById("moduleDuration").value),
        instructorId: parseInt(document.getElementById("moduleInstructorId").value)
    };

    if (editingModuleId) {
        await fetch(`${API_URL}/modules/${editingModuleId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(module)
        });
        editingModuleId = null;
    } else {
        await fetch(`${API_URL}/modules`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(module)
        });
    }

    this.reset();
    loadModules();
});

function editModule(id, name, description, duration, instructorId) {
    editingModuleId = id;
    document.getElementById("moduleName").value = name;
    document.getElementById("moduleDescription").value = description;
    document.getElementById("moduleDuration").value = duration;
    document.getElementById("moduleInstructorId").value = instructorId;
}

async function deleteModule(id) {
    if (confirm("Delete this module?")) {
        await fetch(`${API_URL}/modules/${id}`, { method: "DELETE" });
        loadModules();
    }
}

// PRACTICES
async function loadPractices() {
    const response = await fetch(`${API_URL}/practices`);
    const data = await response.json();

    const table = document.getElementById("practicesTable");
    table.innerHTML = "";

    data.forEach(practice => {
        const date = practice.date?.split("T")[0];

        table.innerHTML += `
            <tr>
                <td>${practice.id}</td>
                <td>${practice.name}</td>
                <td>${date}</td>
                <td>${practice.grade}</td>
                <td>${practice.observations}</td>
                <td>${practice.studentId}</td>
                <td>${practice.moduleId}</td>
                <td>${practice.instructorId}</td>
                <td>
                    <button onclick="editPractice(${practice.id}, '${practice.name}', '${date}', ${practice.grade}, '${practice.observations}', ${practice.studentId}, ${practice.moduleId}, ${practice.instructorId})">Edit</button>
                    <button onclick="deletePractice(${practice.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById("practiceForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const practice = {
        id: editingPracticeId ?? 0,
        name: document.getElementById("practiceName").value,
        date: document.getElementById("practiceDate").value,
        grade: parseFloat(document.getElementById("practiceGrade").value),
        observations: document.getElementById("practiceObservations").value,
        studentId: parseInt(document.getElementById("practiceStudentId").value),
        moduleId: parseInt(document.getElementById("practiceModuleId").value),
        instructorId: parseInt(document.getElementById("practiceInstructorId").value)
    };

    if (editingPracticeId) {
        await fetch(`${API_URL}/practices/${editingPracticeId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(practice)
        });
        editingPracticeId = null;
    } else {
        await fetch(`${API_URL}/practices`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(practice)
        });
    }

    this.reset();
    loadPractices();
});

function editPractice(id, name, date, grade, observations, studentId, moduleId, instructorId) {
    editingPracticeId = id;
    document.getElementById("practiceName").value = name;
    document.getElementById("practiceDate").value = date;
    document.getElementById("practiceGrade").value = grade;
    document.getElementById("practiceObservations").value = observations;
    document.getElementById("practiceStudentId").value = studentId;
    document.getElementById("practiceModuleId").value = moduleId;
    document.getElementById("practiceInstructorId").value = instructorId;
}

async function deletePractice(id) {
    if (confirm("Delete this practice?")) {
        await fetch(`${API_URL}/practices/${id}`, { method: "DELETE" });
        loadPractices();
    }
}

// SCHEDULES
async function loadSchedules() {
    const response = await fetch(`${API_URL}/schedules`);
    const data = await response.json();

    const table = document.getElementById("schedulesTable");
    table.innerHTML = "";

    data.forEach(schedule => {
        const date = schedule.date?.split("T")[0];

        table.innerHTML += `
            <tr>
                <td>${schedule.id}</td>
                <td>${date}</td>
                <td>${schedule.time}</td>
                <td>${schedule.moduleId}</td>
                <td>
                    <button onclick="editSchedule(${schedule.id}, '${date}', '${schedule.time}', ${schedule.moduleId})">Edit</button>
                    <button onclick="deleteSchedule(${schedule.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById("scheduleForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const schedule = {
        id: editingScheduleId ?? 0,
        date: document.getElementById("scheduleDate").value,
        time: document.getElementById("scheduleTime").value,
        moduleId: parseInt(document.getElementById("scheduleModuleId").value)
    };

    if (editingScheduleId) {
        await fetch(`${API_URL}/schedules/${editingScheduleId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(schedule)
        });
        editingScheduleId = null;
    } else {
        await fetch(`${API_URL}/schedules`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(schedule)
        });
    }

    this.reset();
    loadSchedules();
});

function editSchedule(id, date, time, moduleId) {
    editingScheduleId = id;
    document.getElementById("scheduleDate").value = date;
    document.getElementById("scheduleTime").value = time;
    document.getElementById("scheduleModuleId").value = moduleId;
}

async function deleteSchedule(id) {
    if (confirm("Delete this schedule?")) {
        await fetch(`${API_URL}/schedules/${id}`, { method: "DELETE" });
        loadSchedules();
    }
}

// LOAD ALL
loadStudents();
loadInstructors();
loadModules();
loadPractices();
loadSchedules();