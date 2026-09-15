--3. feladat:
CREATE VIEW programozok AS
SELECT
    CONCAT(FIRST_NAME, ' ', LAST_NAME) AS FULL_NAME
FROM employees
JOIN jobs
    ON employees.JOB_ID = jobs.JOB_ID
WHERE jobs.JOB_TITLE = 'Programmer';

--4. feladat:
SELECT * FROM programozok;

--5. feladat:
CREATE VIEW munkakorletszam AS
SELECT
    jobs.JOB_TITLE,
    COUNT(*) AS db
FROM employees
JOIN jobs
    ON employees.JOB_ID = jobs.JOB_ID
GROUP BY jobs.JOB_TITLE;

--6. feladat:

--7. feladat:

--8. feladat:

--9. feladat:

--10. feladat:

--11. feladat:

--12. feladat:

--13. feladat:

--14. feladat:

--15. feladat:

--16. feladat:
