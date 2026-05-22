# Restaurant Management System

He thong gom mot backend dung chung va 3 client chay song song:

- Backend API: `http://127.0.0.1:3000`
- Web khach hang: `http://127.0.0.1:3000/customer/`
- Web nhan vien: `http://127.0.0.1:3000/staff/`
- Web admin: `http://127.0.0.1:3000/admin-web/`
- Android/Flutter app: dung cung backend API o tren.

## Chạy 2 terminal song song: chạy backend trước rồi qua cmd mới chạy frontend ở dưới

## Chay nhanh tat ca

```powershell
cd backend
npm install
npm start
```

Neu muon mo web nhan vien/admin bang backend, build Flutter web truoc:

```powershell
cd frontend
flutter pub get
flutter build web
cd ..\backend
npm start
```

Sau do mo:

- Khach hang: `http://127.0.0.1:3000/customer/`
- Nhan vien: `http://127.0.0.1:3000/staff/`
- Admin: `http://127.0.0.1:3000/admin-web/`

## Tai khoan va mat khau

Tat ca mat khau demo la `123`.

Tai khoan admin/nhan vien co 12 tai khoan:

| Vai tro | Tai khoan | Mat khau |
| --- | --- | --- |
| Admin | `admin` | `123` |
| Nhan vien | `staff` | `123` |
| Thu ngan | `cashier` | `123` |
| Ke toan | `accountant` | `123` |
| Phuc vu | `waiter02` | `123` |
| Bep | `chef` | `123` |
| Pha che | `barista` | `123` |
| Le tan | `reception` | `123` |
| Giam sat | `supervisor` | `123` |
| Bao ve | `guard` | `123` |
| Phu bep | `kitchen` | `123` |
| Phuc vu | `waiter03` | `123` |

Tai khoan khach hang co 100 tai khoan:

- `customer001 / 123`
- `customer002 / 123`
- ...
- `customer100 / 123`

## Du lieu demo

Sau khi reset, he thong co:

- 12 nhan vien va 12 tai khoan nhan vien.
- 100 tai khoan khach hang.
- 16 ban voi 3 trang thai: `available`/trong, `reserved`/da dat, `occupied`/dang su dung.
- 52 mon gom mon chinh, lau/nuong, khai vi, an vat, do uong, trang mieng.
- Nhieu hoa don lien ket ban, mon an, nhan vien va khach hang neu don do khach tu web tao.
- Hoa don do nhan vien/admin tao khong bat buoc lien ket tai khoan khach hang.
- Co san hoa don da thanh toan, hoa don dang mo, cong no va lich su thanh toan cho khach.
- Cham cong nhieu thang cho mot so nhan vien, moi ngay 08:00-18:00, luong 300000 VND/ngay.

Reset du lieu:

```powershell
Invoke-RestMethod -Method Post http://127.0.0.1:3000/reset
```

## Luong lien ket chinh

1. Khach hang dang nhap web khach hang.
2. Khach chon ban va dat ban: ban doi sang `reserved`.
3. Khach chon mon va gui don: he thong tao hoa don `open`, ban doi sang `occupied`, hoa don co `customerId`.
4. Admin/nhan vien dang nhap web admin/nhan vien hoac app Android se thay ban va hoa don moi.
5. Khi admin/nhan vien bam da thanh toan: hoa don doi sang `paid`, ban quay ve `available`.
6. Hoa don da thanh toan cua khach se hien trong lich su thanh toan tren web khach hang.
7. Neu nhan vien/admin tu tao hoa don tai ban, he thong van cho thanh toan binh thuong ma khong can tai khoan khach.

## Giao dien nghiep vu moi

- Web khach hang dung mau chinh trang, den va xanh nuoc bien.
- Web nhan vien va web admin dung chung app Flutter; khac nhau theo tai khoan dang nhap.
- Man hinh Hoa don co bo loc `Tat ca`, `Da tra`, `Dang dung`.
- Nhan vao hoa don se mo chi tiet: thong tin khach, nhan vien, cac lan goi mon va tong tien.
- Khi nhan vien/admin goi mon tai ban, bam mon chi dua vao danh sach tam.
- Bam `Xac nhan chon mon` moi ghi vao hoa don va tao lan goi mon: `Lan 1`, `Lan 2`, `Lan 3`...
- Bam `Huy bo` hoac `Bo het danh sach mon chon` se xoa danh sach tam, khong ghi vao hoa don.
- Ban dang dung van co the nhap vao de goi them; lan xac nhan moi duoc cong vao cung hoa don cua ban.
- Thong ke cho chon ngay/thang/nam va lui/tien qua nhieu thoi diem.

## Chay app Android

Emulator Android co the chay:

```powershell
cd frontend
adb devices
flutter run -d <emulator-id>
hoặc
flutter run 
```

App se thu ket noi backend qua `http://10.0.2.2:3000`.

May dien thoai that qua USB debug:

```powershell
adb reverse tcp:3000 tcp:3000
cd frontend
flutter run -d <device-id> --dart-define=API_BASE_URL=http://127.0.0.1:3000
```

Neu cai APK len dien thoai that va khong dung USB reverse, may tinh chay backend va dien thoai phai cung Wi-Fi. Build voi IP LAN cua may tinh:

```powershell
cd frontend
flutter build apk --debug --dart-define=API_BASE_URL=http://<IP_MAY_TINH>:3000
```

Vi du:

```powershell
flutter build apk --debug --dart-define=API_BASE_URL=http://192.168.1.10:3000
```

Chay bang Android Studio:

1. Mo thu muc `frontend/android` hoac ca thu muc `frontend` trong Android Studio.
2. Dam bao backend dang chay `http://127.0.0.1:3000`.
3. Neu dung emulator, app se thu ket noi `http://10.0.2.2:3000`.
4. Neu dung may that, chay `adb reverse tcp:3000 tcp:3000` hoac build voi IP LAN bang `API_BASE_URL`.

## Kiem thu da tao

File test case chinh:

- `Document/test-cases/all-test-cases-expandtesting-style.md`
- `Document/test-cases/all-test-cases-expandtesting-style.docx`
- `Document/test-cases/all-test-cases-expandtesting-style.xlsx`

Bo test case hien co 195 test case theo dang:

- `## ... Automation Test Cases`
- `### Test Case n: ...`
- Preconditions
- Steps
- Expected Result
- Status

Chay lai sinh file test case:

```powershell
node tools/generate_markdown_test_cases.js
python tools/export_test_cases_office.py
```

## Lenh kiem tra code

Backend:

```powershell
cd backend
node --check server.js
node --check src\store.js
node --check src\seedData.js
node --check src\routes\customer.js
node --check src\routes\employees.js
```

Flutter:

```powershell
cd frontend
flutter analyze
flutter test
flutter build web
flutter build apk --debug
```
