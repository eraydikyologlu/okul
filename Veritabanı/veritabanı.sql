
DROP TABLE IF EXISTS EtkinlikTipiTablosu;
CREATE TABLE EtkinlikTipiTablosu
(
    EtkinlikID INT PRIMARY KEY,
    Kategori VARCHAR(50) -- Kategori boyutunu ihtiyaca göre ayarlayabilirsiniz
    -- Diğer özellikleri buraya ekleyebilirsiniz
);

DROP TABLE IF EXISTS BiletTablosu CASCADE; 
CREATE TABLE BiletTablosu
(
    BiletNo varchar(10) PRIMARY KEY,
    BiletFiyati varchar(4),
    EtkinlikID INT,
    FOREIGN KEY (EtkinlikID) REFERENCES EtkinlikYeriTablosu(EtkinlikID)
);


DROP TABLE IF EXISTS MusteriTablosu CASCADE;
CREATE TABLE MusteriTablosu
(
	TCNo varchar(11) PRIMARY KEY,
	TelefonNo varchar(11),
	eposta varchar(30),
	sifre varchar(15)
)

INSERT INTO MusteriTablosu(TCNo,TelefonNo,eposta,sifre) VALUES
('14044181496','05388673188','eraydikyologlu4@gmail.com','erayasd123')


-- SepetTablosu'nu oluştur
DROP TABLE IF EXISTS SepetTablosu;
CREATE TABLE SepetTablosu
(
    SepetID INT PRIMARY KEY,
    TC VARCHAR(11),
    BiletNo VARCHAR(10),
    SepeteEklenmeTarihi TIMESTAMP,
    FOREIGN KEY (TC) REFERENCES MusteriTablosu(TCNo),
    FOREIGN KEY (BiletNo) REFERENCES BiletTablosu(BiletNo)
);

------------------------------------------------


-- TakimTablosu'nu oluştur
DROP TABLE IF EXISTS TakimTablosu;
CREATE TABLE TakimTablosu
(
    TakimID SERIAL PRIMARY KEY,
    TakimAdi VARCHAR(50) NOT NULL,
    Lig VARCHAR(20) NOT NULL
);

-- StadyumTablosu'nu oluştur
DROP TABLE IF EXISTS StadyumTablosu;
CREATE TABLE StadyumTablosu
(
    StadyumID SERIAL PRIMARY KEY,
    StadyumAdi VARCHAR(50) NOT NULL,
    Kapasite INT NOT NULL,
    TakimID INT,
    FOREIGN KEY (TakimID) REFERENCES TakimTablosu(TakimID)
);

-- TribunTablosu'nu oluştur
DROP TABLE IF EXISTS TribunTablosu;
CREATE TABLE TribunTablosu
(
    TribunID SERIAL PRIMARY KEY,
    TribunAdi VARCHAR(50) NOT NULL,
    Kapasite INT NOT NULL,
    StadyumID INT,
    FOREIGN KEY (StadyumID) REFERENCES StadyumTablosu(StadyumID)
);

-- EtkinlikYeriTablosu'nu güncelle
DROP TABLE IF EXISTS EtkinlikYeriTablosu;
CREATE TABLE EtkinlikYeriTablosu
(
    EtkinlikID INT PRIMARY KEY,
    StadyumID INT,
    TribunID INT,
    Blok VARCHAR(10),
    Sira INT,
    Koltuk INT,
    Kapi VARCHAR(5),
    FOREIGN KEY (StadyumID) REFERENCES StadyumTablosu(StadyumID),
    FOREIGN KEY (TribunID) REFERENCES TribunTablosu(TribunID)
);

-- Örnek takımları ekle
INSERT INTO TakimTablosu (TakimAdi, Lig)
VALUES
    ('Galatasaray', 'Süper Lig'),
    ('Fenerbahçe', 'Süper Lig'),
    ('Beşiktaş', 'Süper Lig');

-- Örnek stadyumları ekle
INSERT INTO StadyumTablosu (StadyumAdi, Kapasite, TakimID)
VALUES
    ('Türk Telekom Stadyumu', 52627, 1),
    ('Şükrü Saracoğlu Stadyumu', 50000, 2),
    ('Vodafone Park', 42728, 3);

-- Örnek tribünleri ekle
INSERT INTO TribunTablosu (TribunAdi, Kapasite, StadyumID)
VALUES
    ('Bati Tribunu', 15000, 1),
    ('Doğu Tribunu', 12000, 1),
    ('Maraton Tribunu', 18000, 2),
    ('Kuzey Tribunu', 14000, 3);


-- Örnek etkinlik yerini ekle
INSERT INTO EtkinlikYeriTablosu (EtkinlikID, StadyumID, TribunID, Blok, Sira, Koltuk, Kapi)
VALUES
    (1, 1, 1, '107', 5, 7, 'K3,K2');


SELECT St.StadyumAdi, Tr.TribunAdi, Eyt.Blok, Eyt.Sira, Eyt.Koltuk, Eyt.Kapi
FROM EtkinlikYeriTablosu AS Eyt
JOIN StadyumTablosu AS St ON Eyt.StadyumID = St.StadyumID
JOIN TribunTablosu AS Tr ON Eyt.TribunID = Tr.TribunID;




INSERT INTO BiletTablosu (BiletNo, BiletFiyati, EtkinlikID)
VALUES 
    ('B12345', '150', 1)


SELECT 
    B.BiletNo, 
    B.BiletFiyati, 
    St.StadyumAdi, 
    Tr.TribunAdi, 
    E.Blok, 
    E.Sira, 
    E.Koltuk, 
    E.Kapi
FROM BiletTablosu AS B
JOIN EtkinlikYeriTablosu AS E ON B.EtkinlikID = E.EtkinlikID
JOIN StadyumTablosu AS St ON E.StadyumID = St.StadyumID
JOIN TribunTablosu AS Tr ON E.TribunID = Tr.TribunID;

---------------------------------------------------------------------







