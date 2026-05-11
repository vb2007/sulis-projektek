<?php

$errors = [];
$data = [];

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $data["title"] = $_POST["title"] ?? "";
    $data["length"] = isset($_POST["length"]) ? (int) $_POST["length"] : 0;
    $data["director"] = $_POST["director"] ?? "";
    $data["writer"] = $_POST["writer"] ?? "";
    $data["published"] = $_POST["published"] ?? date("Y-m-d");
    $data["viewers"] = isset($_POST["viewers"]) ? (float) $_POST["viewers"] : 0;

    if (isset($_POST["title"])) {
        if (empty($data["title"])) {
            $errors["title"] = "A cím kitöltése kötelező!";
        }
    }

    if (isset($_POST["length"])) {
        if (!is_numeric($_POST["length"])) {
            $errors["length"] = "A hossz legyen szám!";
        } elseif ($data["length"] < 0) {
            $errors["length"] = "A hossz nem lehet negatív!";
        }
    }

    if (isset($_POST["director"])) {
        if (empty($data["director"])) {
            $errors["director"] = "A rendező kitöltése kötelező";
        }
    }

    if (isset($_POST["writer"])) {
        if (empty($data["writer"])) {
            $errors["writer"] = "Az író kitöltése kötelező";
        }
    }

    if (isset($_POST["published"])) {
        if (empty($data["published"])) {
            $errors["published"] = "A megjelenés kitöltése kötelező";
        }
    }

    if (isset($_POST["viewers"])) {
        if (!is_numeric($_POST["viewers"])) {
            $errors["viewers"] = "A nézők száma legyen szám!";
        } elseif ($data["viewers"] < 0) {
            $errors["viewers"] = "A nézők száma nem lehet negatív!";
        }
    }

    // nincs hiba -> save
    if (empty($errors)) {
        $newId = count($episodes) + 1;
        $newEpisode = new Series\Bbc\Sherlock($newId, $data["title"], $data["length"], $data["director"], $data["writer"], $data["published"], $data["viewers"]);

        $episodes[] = $newEpisode;

        $csvLine =
            "\n" . $newId . ";" . $data["title"] . ";" . $data["length"] . ";" . $data["director"] . ";" . $data["writer"] . ";" . $data["published"] . ";" . $data["viewers"];
        file_put_contents(__DIR__ . "/../data/sherlock.csv", $csvLine, FILE_APPEND);

        header("Location: index.php");
        exit();
    }
}
?>

<div class="mx-auto min-w-7xl px-4">
    <h1 class="my-4 text-center text-4xl font-bold text-slate-600"><?= $title ?></h1>

    <?php include __DIR__ . "/../components/form.php"; ?>
</div>
