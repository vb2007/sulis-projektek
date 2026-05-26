<a href="index.php?action=create" class="bg-violet-600 text-white text-center p-1 rounded-md inline-block cursor-pointer font-bold">Koncert rögzítése</a>

<table class="w-full mt-4">
    <thead>
        <tr class="bg-violet-600 text-white">
            <th class="p-1">Név</th>
            <th class="p-1">Helyszín</th>
            <th class="p-1">Típus</th>
            <th class="p-1">Dátum</th>
            <th class="p-1">Ár</th>
        </tr>
    </thead>
    <tbody>
        <?php foreach($concerts as $concert): ?>
        <tr>
            <td class="p-1 text-center"><a href="" class="text-violet-600 underline"><?= $concert->name ?></a></td>
            <td class="p-1 text-center"><?= $concert->location ?></td>
            <td class="p-1 text-center"><?= $concert->type ?></td>
            <td class="p-1 text-center"><?= $concert->date->format('Y-m-d H:i:s') ?></td>
            <td class="p-1 text-center"><span class="bg-violet-600 text-white p-1 rounded"><?= $concert->price ?></span></td>
        </tr>
        <?php endforeach; ?>
    </tbody>
</table>