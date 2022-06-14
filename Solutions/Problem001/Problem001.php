<?php
// imperative
$s = 0;
for ($i = 0; $i < 1000; $i++) {
    if ($i % 3 === 0 || $i % 5 === 0) {
        $s = $s + $i;
    }
}
print_r($s);
print(PHP_EOL);

// declarative
$pred = function ($x) {
    return $x % 3 === 0 || $x % 5 === 0;
};
$s2 = array_sum(
    array_filter(
        range(0, 999, 1),
        $pred
    )
);
print_r($s2);
print(PHP_EOL);
