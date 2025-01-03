-- Coprimefinder
findCoprime :: Integer -> Integer
findCoprime phi = head [e | e <- [2..], gcd e phi == 1]

-- Modular Inverse function
-- d * e mod phi == 1
modInverse :: Integer -> Integer -> Integer
modInverse e phi = 
    let (g, x, _) = gcdExt e phi
    in if g /= 1 then error "e and phi(n) are not coprime" else x `mod` phi

-- Extended Euclidean Algorithm
gcdExt :: Integer -> Integer -> (Integer, Integer, Integer)
gcdExt a 0 = (a, 1, 0)
gcdExt a b = 
    let (g, x, y) = gcdExt b (a `mod` b)
    in (g, y, x - (a `div` b) * y)

-- Function to generate RSA key pair
rsaKeyGen :: Integer -> Integer -> (Integer, Integer, Integer)
rsaKeyGen p q = 
    let n = p * q
        phi = (p - 1) * (q - 1)
        e = findCoprime phi
        d = modInverse e phi
    in  (n, e, d)

main = do
    -- Input values for p and q
    let p = 419933
        q = 889271

    -- Generate key pair
    let (n, e, d) = rsaKeyGen p q

    -- Print
    putStrLn $ "Public key (n, e): (" ++ show n ++ ", " ++ show e ++ ")"
    putStrLn $ "Private key (n, d): " ++ show n ++ ", " ++ show d ++ ")"

        
