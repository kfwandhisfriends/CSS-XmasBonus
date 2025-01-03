--define exp func
modExp :: Integer -> Integer -> Integer -> Integer
modExp base exp modulus
    | exp == 0  = 1
    | otherwise = base^exp `mod` modulus

--main func
main :: IO()
main = do
    -- input 
    let g = 70
    let p = 991
    let a = 815 -- alice's secret key
    let b = 376 -- bob's   secret key

    -- calculate A and B
    let aPublic = modExp g a p
    let bPublic = modExp g b p

    -- calculate K_AB
    let kAB_Alice = modExp bPublic a p
    let kAB_Bob = modExp aPublic b p

    -- check
    putStrLn $ "A (Alice sends to Bob): " ++ show aPublic
    putStrLn $ "B (Bob sends to Alice): " ++ show bPublic
    putStrLn $ "Shared Key K_AB from Alice): " ++ show kAB_Alice
    putStrLn $ "Shared Key K_AB from Bob): " ++ show kAB_Bob
