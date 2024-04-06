import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart

# Gmail hesabı bilgileri
gmail_user = "mail adresini gir"  # Gmail adresinizi buraya girin
gmail_password = "kendi gmail uygulama sifreni gir"  # Gmail parolanızı buraya girin

# Konu ve mesaj içeriği
subject = "Staj"
body = """Merhaba,

Ben Eray Dikyoloğlu, Gazi Üniversitesi Bilgisayar Mühendisliği 3. sınıf öğrencisiyim. Bu yaz zorunlu stajım bulunmakta ve bu yaz stajımı şirketinizde yapmayı çok isterim.

Yapay zeka destekli ürün geliştirme konusunda 1.5 yıldır kendimi geliştirmekteyim. Mobil uygulama ve web sitelerinde yapay zeka kullanılarak geliştirilen çözümler ile uğraşmakta ve işin daha derinine inerek de yapay zeka üzerine çalışmalar yapmaktayım.

Stajım sırasında, yapay zeka ve yazılım geliştirme becerilerimi kullanarak şirketinize katkıda bulunmak istiyorum. Hızlı öğrenen, çalışkan ve araştırmayı seven biriyim. Ekip çalışmasına yatkınım ve yeni bilgilere açığım.

Özgeçmişimi ekte bulabilirsiniz. Staj başvurumla ilgili lütfen benimle iletişime geçmekten çekinmeyin.

İlginiz için teşekkür ederim.

Saygılarımla,

Eray Dikyoloğlu
"""


# E-posta gönderme işlemi
def send_email(subject, body, receiver_email):
    try:
        message = MIMEMultipart()
        message["From"] = gmail_user
        message["To"] = receiver_email
        message["Subject"] = subject
        message.attach(MIMEText(body, "plain"))

        server = smtplib.SMTP_SSL("smtp.gmail.com", 465)
        server.login(gmail_user, gmail_password)
        server.sendmail(gmail_user, receiver_email, message.as_string())
        server.close()
        print(f"{receiver_email} adresine e-posta başarıyla gönderildi.")
    except Exception as e:
        print(f"Hata oluştu: {e}")


# TXT dosyasından alıcı e-posta adreslerini okuma ve e-posta gönderme işlemini gerçekleştirme
def send_emails_from_file(txt_file):
    with open(txt_file, "r") as file:
        for line in file:
            receiver_email = line.strip()
            send_email(subject, body, receiver_email)


if __name__ == "__main__":
    txt_file = "email_addresses.txt"  # E-posta adreslerini içeren TXT dosyası
    send_emails_from_file(txt_file)
