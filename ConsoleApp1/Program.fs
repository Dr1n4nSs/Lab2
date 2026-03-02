open System

let productOfDigits n =
    let rec loop num acc =
        if num = 0 then acc
        else
            let digit = num % 10
            loop (num / 10) (acc * digit)
    
    let value = abs n
    if value = 0 then 0 else loop value 1

let rec readElements count acc =
    if count <= 0 then
        List.rev acc
    else
        printf "Введите число (%d осталось): " count
        match Int32.TryParse(Console.ReadLine()) with
        | (true, value) -> readElements (count - 1) (value :: acc)
        | _ -> 
            printfn "Введите целое число."
            readElements count acc

[<EntryPoint>]
let main _ =
    printf "Введите количество элементов: "
    match Int32.TryParse(Console.ReadLine()) with
    | (true, n) when n >= 0 ->
        let originalList = readElements n []
    
        let processedList = originalList |> List.map productOfDigits
        
        printfn "\nИсходный список: %A" originalList
        printfn "Произведения цифр: %A" processedList
    | _ -> printfn "Некорректный ввод."
    0
