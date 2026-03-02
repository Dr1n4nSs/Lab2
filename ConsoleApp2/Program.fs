open System

let tryParseBinary (input: string) =
    try
        let value = Convert.ToInt32(input, 2)
        if value >= 1 && value <= 9 then Some(value)
        else None
    with _ -> None

let rec readValidElements count acc =
    if count <= 0 then
        List.rev acc
    else
        printf "Введите двоичное число (1-1001), осталось %d: " count
        let input = Console.ReadLine()
        match tryParseBinary input with
        | Some(v) -> readValidElements (count - 1) (v :: acc)
        | None -> 
            printfn "Число должно быть двоичным и в диапазоне 1..1001"
            readValidElements count acc

[<EntryPoint>]
let main _ =
    printf "Введите количество элементов: "
    match Int32.TryParse(Console.ReadLine()) with
    | (true, n) when n > 0 ->
        let numbers = readValidElements n []
        
        let totalSum = numbers |> List.fold (fun acc x -> acc + x) 0
        
        printfn "\nВведенные числа (в 10-й системе): %A" numbers
        printfn "Итоговая сумма: %d" totalSum
        
    | _ -> printfn "Некорректный ввод."
    0

