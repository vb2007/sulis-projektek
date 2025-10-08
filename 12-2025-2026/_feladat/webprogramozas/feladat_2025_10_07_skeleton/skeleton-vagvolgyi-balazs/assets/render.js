document.querySelector("#task-01 .result").textContent =
  task01(data01) ?? "Még nincs eredmény";
document.querySelector("#task-02 .result").textContent =
  task02(data02) ?? "Még nincs eredmény";
document.querySelector("#task-03 .result").textContent =
  task03(data03) ?? "Még nincs eredmény";
document.querySelector("#task-04 .result").textContent =
  task04(data01) ?? "Még nincs eredmény";
document.querySelector("#task-05 .result").textContent =
  JSON.stringify(task05(data02)) ?? "Még nincs eredmény";

document.querySelector("#task-01>code").textContent = JSON.stringify(data01);
document.querySelector("#task-02>code").textContent = JSON.stringify(data02);
document.querySelector("#task-03>code").textContent = JSON.stringify(data03);
document.querySelector("#task-04>code").textContent = JSON.stringify(data01);
document.querySelector("#task-05>code").textContent = JSON.stringify(data02);
