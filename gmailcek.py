from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from bs4 import BeautifulSoup

# Web sürücüsünün başlatılması
driver = (
    webdriver.Chrome()
)  # Chrome sürücüsü kullanılıyor, uygun sürücüyü kullanmalısınız

# Ana URL
base_url = "https://www.hacettepeteknokent.com.tr/tr/firma_rehberi/yazilim-29"

# E-posta adreslerini tutacak txt dosyası
output_file = "email_addresses.txt"


# Fonksiyon: Verilen URL'deki şirket sayfasından e-posta adresini alır
def get_email_address(company_url):
    driver.get(company_url)
    try:
        email_element = WebDriverWait(driver, 10).until(
            EC.presence_of_element_located(
                (By.XPATH, '//*[@id="main"]/div[1]/div/div/div[2]/div[4]')
            )
        )
        email = email_element.text.strip().split()[-1]
        return email
    except Exception as e:
        print(f"Hata: {e}")
        return None


# Ana fonksiyon: Şirket sayfalarını dolaşarak e-posta adreslerini alır
def scrape_emails():
    with open(output_file, "w") as file:
        page_num = 1
        while True:
            page_url = f"{base_url}?page={page_num}"
            driver.get(page_url)
            soup = BeautifulSoup(driver.page_source, "html.parser")
            company_links = soup.find_all("div", class_="firma_adi")
            if not company_links:
                break  # Şirket listesi bulunamadıysa döngüden çık
            for link in company_links:
                company_url = (
                    "https://www.hacettepeteknokent.com.tr" + link.find("a")["href"]
                )
                email = get_email_address(company_url)
                if email:
                    file.write(email + "\n")
            page_num += 1


if __name__ == "__main__":
    scrape_emails()
    driver.quit()  # Sürücüyü kapat
