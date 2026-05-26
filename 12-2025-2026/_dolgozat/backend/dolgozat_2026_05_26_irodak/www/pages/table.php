<h1 class="text-3xl font-bold text-center my-4"><?= $title ?></h1>

<table class="w-11/12 max-w-250 mx-auto drop-shadow-md mb-4">
    <thead>
        <tr class="bg-lime-400">
            <th class="p-1 rounded-tl-lg">Név</th>
            <th class="p-1">Cím</th>
            <th class="p-1">Szobák száma</th>
            <th class="p-1 rounded-tr-lg">Ár</th>
        </tr>
    </thead>
        <?php foreach($offices as $office): ?>
            <tr class="text-center [&:last-child>td:first-child]:rounded-bl-lg [&:last-child>td:last-child]:rounded-br-lg odd:bg-lime-50 even:bg-lime-100">
                <td class="p-1"><a class="text-blue-800 hover:underline" href=""><?= $office->name ?></a></td>
                <td class="p-1"><?= $office->address ?></td>
                <td class="p-1"><?= $office->rooms ?></td>
                <td class="p-1"><?= $office->price ?></td>
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>