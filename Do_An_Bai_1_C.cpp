#include<stdio.h>
#include<string.h>
#include<conio.h>
#include<stdlib.h>
#include<windows.h>
#define SIZE 100

struct Date
{
	int day, month, year;
};

struct Employee
{
	char hoten[SIZE], sdt[13];
	Date sinhnhat, ngayvaolam;
};

struct Node
{
	Employee data;
	Node *pNext;
	Node *pPrevious;
};

struct DoubleList
{
	Node *pHead;
	Node *pTail;
};

void Nhap_Date(Date &data);
void Xuat_Date(Date data);
bool Check_Nam_Nhuan(Date data);
bool Check_Date(Date data);
void Nhap_Employee(Employee &data);
void Tach_Ten(char datahoten[], char ten[]);
void Xuat_Employee(Employee data);
void Initialize_List(DoubleList &list);
int SizeOfList(DoubleList list);
Node *Create_Node(Employee data);
bool Check_Empty_List(DoubleList list);
void Print_List(DoubleList list);
void Insert_First(DoubleList &list, Employee data);
void Insert_Last(DoubleList &list, Employee data);
void Insert_Mid(DoubleList &list, int &vitri, Employee data);
void Remove_First(DoubleList &list);
void Remove_Last(DoubleList &list);
void Remove_Mid(DoubleList &list, int &vitri);
void Tim_Kiem_Employee_Theo_SDT(DoubleList list, Employee &data);
bool Kiem_Tra_Date_Lon_Hon(Date data1, Date data2);
void Danh_Sach_Employee_Vao_Lam_Sau_Ngay_Cho_Truoc(DoubleList list,Employee &data);
void Nhap_Danh_Sach_Employee(DoubleList &list);
void Sort_List_Selection_Sort(DoubleList &list);
void Sort_List_Quick_Sort(DoubleList &list);
void Merge_Two_List(DoubleList &list1);
void Xoa_Employee_Di_Lam_Truoc_Ngay_Duoc_Nhap(DoubleList &list,Employee &data);
Node *Employee_Lon_Tuoi_Nhat(DoubleList list);
int Design_Menu();
//void Start_Interface();
void Thoat_Chuong_Trinh(DoubleList &list);
void So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(DoubleList list);
void End_Chuc_Nang(DoubleList &list);
void Active_Program();

int main()
{
	Active_Program();
	
	return 0;
}

void Nhap_Date(Date &data)
{
	fflush(stdin);
	scanf("%d %d %d",&data.day,&data.month,&data.year);
	while(Check_Date(data)==false)
	{
		printf("Ban vua nhap sai ngay thang nam cua nhan vien, de nghi nhap lai!\n");
		fflush(stdin);
		scanf("%d %d %d",&data.day,&data.month,&data.year);
	}
}

void Xuat_Date(Date data)
{
	printf("%d / %d / %d\n",data.day,data.month,data.year);
}

bool Check_Nam_Nhuan(Date data)
{
	if(data.year%400==0 || (data.year%4==0 && data.year%100!=0))
	{
		return true;
	}
	return false;
}

bool Check_Date(Date data)
{
	int temp=data.month;
	switch(temp)
	{
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			if(data.day>=1 && data.day<=31)
			{
				return true;
			}
			break;
		case 4: case 6: case 9: case 11:
			if(data.day>=1 && data.day<=30)
			{
				return true;
			}
			break;
		case 2:
			if( (Check_Nam_Nhuan(data)==true &&(data.day>=1&&data.day<=29)) || (Check_Nam_Nhuan(data)==false &&(data.day>=1&&data.day<=28)) )
			{
				return true;
			}
			break;
		default:
			break;
	}
	return false;
}

void Nhap_Employee(Employee &data)
{
	printf("\nNhap ho va ten:  ");
	fflush(stdin);
	//getchar();
	gets(data.hoten);
	printf("Nhap so dien thoai:  ");
	fflush(stdin);
	gets(data.sdt);
	printf("Nhap ngay, thang, nam sinh:  ");
	Nhap_Date(data.sinhnhat);
	//fflush(stdin);
	printf("Nhap ngay, thang, nam vao lam:  ");
	Nhap_Date(data.ngayvaolam);
}

void Tach_Ten(char datahoten[], char ten[])
{
	int len = strlen(datahoten);
	int i;
	for(i=len-1;i>=0;i--)
	{
		if(datahoten[i] == ' ')
		{
			strcpy(ten,datahoten+i+1);
			break;
		}
	}
	
}

void Xuat_Employee(Employee data)
{
	printf("\nHo ten:  ");
	puts(data.hoten);
	printf("So dien thoai:  ");
	puts(data.sdt);
	printf("Ngay, thang, nam sinh:  ");
	Xuat_Date(data.sinhnhat);
	printf("Ngay, thang, nam vao lam:  ");
	Xuat_Date(data.ngayvaolam);
}

void Initialize_List(DoubleList &list)
{
	list.pHead=list.pTail=NULL;
}

int SizeOfList(DoubleList list)
{
	Node *pTemp=list.pHead;
	int nSize=0;
	while(pTemp!=NULL)
	{
		pTemp=pTemp->pNext;
		nSize++;
	}
	return nSize;
}

Node *Create_Node(Employee data)
{
	Node *pNode = new Node;
	if(pNode!=NULL)
	{
		pNode->data=data;
		pNode->pNext=NULL;
		pNode->pPrevious=NULL;
	}
	else
	{
		printf("\nCap phat bo nho that bai!\n");
		return NULL;
	}
	return pNode;
	
}

bool Check_Empty_List(DoubleList list)
{
	Node *pNode = list.pHead;
	if(pNode==NULL)
	{
		return true;
	}
	return false;
}

void Print_List(DoubleList list)
{
	int n=SizeOfList(list);
	Node *pTemp=list.pHead;
	printf("\nDanh sach Employee hien tai:  %d Employee\n",n);
	if(pTemp==NULL)
	{
		printf("\nDanh sach rong!\n");
	}
	int i=1;
	while(pTemp!=NULL)
	{
		printf("\n - Employee (%d) - Vi tri (%d)",i,i-1);
		Xuat_Employee(pTemp->data);
		pTemp=pTemp->pNext;
		i++;
	}
}

void Insert_First(DoubleList &list, Employee data)
{
	Node *pNode = Create_Node(data);
	if(list.pHead==NULL)
	{
		list.pHead=list.pTail=pNode;
	}
	else
	{
		pNode->pNext=list.pHead;
		list.pHead->pPrevious=pNode;
		list.pHead=pNode;	
	}	
}

void Insert_Last(DoubleList &list, Employee data)
{
	Node *pNode = Create_Node(data);
	if(list.pTail==NULL)
	{
		list.pHead=list.pTail=pNode;
	}
	else
	{
		list.pTail->pNext=pNode;
		pNode->pPrevious=list.pTail;
		list.pTail=pNode;
	}
}

void Insert_Mid(DoubleList &list, int &vitri, Employee data)
{	
	printf("\nNhap vi tri Employee ma ban muon chen Employee moi vao sau no bang Insert_Mid:  ");
	scanf("%d",&vitri);
	while(vitri<0 || vitri >=SizeOfList(list))
	{
		printf("\nBan da nhap sai vi tri, moi ban nhap lai:  ");
		scanf("%d",&vitri);
	}
	if(vitri == SizeOfList(list)-1)
	{
		Insert_Last(list,data);
	}
	else
	{
		Node *pTemp = Create_Node(data);
		Node *pInsert=list.pHead;
		int i=0;
		while(pInsert!=NULL)
		{
			if(i==vitri)
			{
				break;
			}
			pInsert=pInsert->pNext;
			i++;
		}
		pTemp->pNext=pInsert->pNext;
		pTemp->pPrevious=pInsert;
		pInsert->pNext->pPrevious=pTemp;;
		pInsert->pNext=pTemp;		
	}	
}

void Remove_First(DoubleList &list)
{
	Node *pTemp= list.pHead;
	if(pTemp==NULL)
	{
		printf("\nDanh sach rong!\n");
	}
	else
	{
		list.pHead=list.pHead->pNext;
		list.pHead->pPrevious=NULL;
		pTemp->pNext=NULL;
		pTemp->pPrevious=NULL;
		delete pTemp;
		pTemp=NULL;
	}
}

void Remove_Last(DoubleList &list)
{
	Node *pTemp=list.pTail;
	if(list.pTail==NULL)
	{
		printf("\nDanh sach rong!\n");
	}
	else
	{
		list.pTail=list.pTail->pPrevious;
		list.pTail->pNext=NULL;
		pTemp->pNext=NULL;
		pTemp->pPrevious=NULL;
		delete pTemp;
		pTemp=NULL;
	}
}

void Remove_Mid(DoubleList &list, int &vitri)
{
	printf("\nNhap vi tri Employee ma ban muon xoa 1 Employee ngay sau no:  ");
	scanf("%d",&vitri);
	while(vitri<0 || vitri >=SizeOfList(list)-1)
	{
		printf("\nBan da nhap sai vi tri, moi ban nhap lai:  ");
		scanf("%d",&vitri);
	}
	if(vitri==SizeOfList(list)-2)
	{
		Remove_Last(list);
	}
	else
	{
		int i=0;
		Node *pRemove=list.pHead;
		Node *pPre_Remove=NULL;
		if(pRemove==NULL)
		{
			printf("Danh sach rong!\n");
			return;
		}
		while(pRemove!=NULL)
		{
			pPre_Remove=pRemove;
			pRemove=pRemove->pNext;
			if(i==vitri)
			{
				break;
			}
			i++;
		}
		pPre_Remove->pNext=pRemove->pNext;
		pRemove->pNext->pPrevious=pPre_Remove;
		pRemove->pPrevious=NULL;
		pRemove->pNext=NULL;
		delete pRemove;
		pRemove=NULL;	
	}
	
}

void Tim_Kiem_Employee_Theo_SDT(DoubleList list, Employee &data)
{
	if(list.pHead==NULL)
	{
		printf("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay\n");
	}
	else
	{
		printf("\nNhap so dien thoai cua Employee ma ban muon tim trong danh sach:  ");
		fflush(stdin);
		gets(data.sdt);
		Node *pTemp=list.pHead;
		int i=1, dem=0;
		while(pTemp!=NULL)
		{
			if(stricmp(pTemp->data.sdt,data.sdt)==0)
			{
				printf("\nDa tim thay Employee: %s o vi tri thu %d trong danh sach!\n",pTemp->data.hoten,i-1);
				dem++;
				break;
			}
			pTemp=pTemp->pNext;
			i++;
		}
		if(dem==0)
		{
			printf("\nKhong co Employee nao co sdt: %s trong danh sach",data.sdt);
		}
	}
}

bool Kiem_Tra_Date_Lon_Hon(Date data1, Date data2)
{
	if(data2.year > data1.year)
	{
		return true;
	}
	else if(data2.year == data1.year)
	{
		if(data2.month > data1.month)
		{
			return true;
		}
		else if(data2.month == data1.month)
		{
			if(data2.day > data1.day)
			{
				return true;
			}
		}
	}
	return false;
}

void Danh_Sach_Employee_Vao_Lam_Sau_Ngay_Cho_Truoc(DoubleList list,Employee &data)
{
	if(list.pHead==NULL)
	{
		printf("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay\n");
	}
	else
	{
		printf("\nNhap ngay, thang, nam ma ban muon so sanh de tim Employee di lam sau ngay nay:  ");
		Nhap_Date(data.ngayvaolam);
		Node *pTemp = list.pHead;
		int i=1,dem=0;
		while(pTemp!=NULL)
		{
			if(Kiem_Tra_Date_Lon_Hon(data.ngayvaolam,pTemp->data.ngayvaolam)==true)
			{
				printf("\n - Employee (%d) - Vi tri (%d)\n",i,i-1);
				Xuat_Employee(pTemp->data);
				dem++;
			}
			i++;
			pTemp=pTemp->pNext;
		}
		if(dem==0)
		{
			printf("\nKhong co Employee nao di lam sau ngay ");
			Xuat_Date(data.ngayvaolam);
		}
		else
		{	
			printf("\nTong cong co %d Employee vao lam sau ngay ",dem);
			Xuat_Date(data.ngayvaolam);
		}
	}
}

void Nhap_Danh_Sach_Employee(DoubleList &list)
{
	//Initialize_List(list);
	printf("\nNhap so luong Employee trong danh sach ban dau:  ");
	int n;
	scanf("%d",&n);
	for(int i=0;i<n;i++)
	{
		Employee data;
		Nhap_Employee(data);
		Insert_Last(list,data);
	}
}

void Sort_List_Selection_Sort(DoubleList &list)
{
	//Truong hop danh sach rong hoac chi co 1 phan tu
	if(list.pHead==list.pTail)
	{
		printf("\nDanh sach co it hon 2 Employee nen khong the sap xep\n");
	}
	else
	{
		int minPos,i,j;
		int n=SizeOfList(list);
		Node *pI=list.pHead;
		for(i=0;i<n-1;i++)
		{
			minPos=i;
			Node *MinPos=pI;
			Node *pJ=pI->pNext;
			for(j=i+1;j<n;j++)
			{
				char data_minPos[100];
				char data_pJ[100];
				Tach_Ten(MinPos->data.hoten,data_minPos);
				Tach_Ten(pJ->data.hoten,data_pJ);
				if( (int)data_pJ[0] < (int)data_minPos[0] || stricmp(data_pJ,data_minPos)<0 )
				{
					minPos=j;
					MinPos=pJ;
				}	
				pJ=pJ->pNext;	
			}
			if(minPos!=i)
			{
				Employee Temp = pI->data;
				pI->data = MinPos->data;
				MinPos->data=Temp;
			}
			pI=pI->pNext;
		}		
	}
}

void Sort_List_Quick_Sort(DoubleList &myList)
{
	//Truong hop danh sach rong hoac co 1 phan tu
	if(myList.pHead==myList.pTail)
	{
		//printf("\nDanh sach co it hon 2 Employee nen khong the sap xep\n");
		return;
	}
	else
	{
		DoubleList myList1;
		DoubleList myList2;
		Node *pivot;
		Node *p;
		Initialize_List(myList1);
		Initialize_List(myList2);
		//Phan hoach danh sach thanh 2 danh sach con
		pivot=myList.pHead; //Phan tu cam canh
		p=myList.pHead->pNext;
		while(p!=NULL)
		{
			Node *q=p;
			p=p->pNext;
			q->pNext=NULL;
			char data_q[100];
			char data_pivot[100];
			Tach_Ten(q->data.hoten,data_q);
			Tach_Ten(pivot->data.hoten,data_pivot);
			if( (int)data_q[0] < (int)data_pivot[0] || stricmp(data_q,data_pivot) <0 )
			{
				Insert_Last(myList1,q->data); //Them vao cuoi danh sach 1
			}
			else
			{
				Insert_Last(myList2,q->data); //Them vao cuoi danh sach 2
			}
		};
		//Goi de quy sap xep cho cac danh sach con
		Sort_List_Quick_Sort(myList1);
		Sort_List_Quick_Sort(myList2);
		//Ghep noi danh sach 1 + pivot
		if(!Check_Empty_List(myList1))
		{
			myList.pHead=myList1.pHead;
			myList1.pTail->pNext=pivot;
		}
		else
		{
			myList.pHead=pivot;
		}
		//Ghep noi pivot + danh sach 2
		pivot->pNext=myList2.pHead;
		if(!Check_Empty_List(myList2))
		{
			myList.pTail=myList2.pTail;
		}
		else
		{
			myList.pTail=pivot;
		}	
	}
}

void Merge_Two_List(DoubleList &list1)
{
	DoubleList list2;
	Initialize_List(list2);
	printf("\nKhoi tao DoubleList thu 2 ...\n");
	Nhap_Danh_Sach_Employee(list2);
	Node *pTemp=list2.pHead;
	while(pTemp!=NULL)
	{
		Insert_Last(list1,pTemp->data);
		pTemp=pTemp->pNext;
	}
	Sort_List_Selection_Sort(list1);

}

void Xoa_Employee_Di_Lam_Truoc_Ngay_Duoc_Nhap(DoubleList &list,Employee &data)
{
	DoubleList list_Temp;
	Initialize_List(list_Temp);
	printf("\nNhap ngay ma ban muon dung de xoa Employees di lam truoc ngay nay:  ");
	Nhap_Date(data.ngayvaolam);
	Node *pRemove = list.pHead;
	int i=0;
	while(pRemove!=NULL)
	{
		if(Kiem_Tra_Date_Lon_Hon(pRemove->data.ngayvaolam,data.ngayvaolam)==false)
		{
			Insert_Last(list_Temp,pRemove->data);
		}
		pRemove=pRemove->pNext;
	}
	list=list_Temp;
}

Node *Employee_Lon_Tuoi_Nhat(DoubleList list)
{
	Node *data_Compare_MIN=list.pHead;
	Node *pTemp=list.pHead->pNext;
	while(pTemp!=NULL)
	{
		if(Kiem_Tra_Date_Lon_Hon(pTemp->data.sinhnhat,data_Compare_MIN->data.sinhnhat)==true)
		{
			//data_Compare_MIN->data=pTemp->data;
			data_Compare_MIN=pTemp;
		}
		pTemp=pTemp->pNext;
	}
	return data_Compare_MIN;
	
}

int Design_Menu()
{
	Sleep(250);
	system("cls");
	printf("\n==================== EMPLOYEE MANAGEMENT PROGRAM ===================================\n");
	printf("|                                                                                    |\n");
	printf("|       1. Nhap Danh Sach Employee                                                   |\n");
	printf("|       2. Xuat Danh Sach Employee Hien Tai                                          |\n");
	printf("|       3. Chen Them Employee Vao Dau Danh Sach Employee Hien Tai                    |\n");
	printf("|       4. Chen Them Employee Vao Cuoi Danh Sach Employee Hien Tai                   |\n");
	printf("|       5. Chen Them Employee Vao Sau 1 Vi Tri Ma Ban Muon                           |\n");
	printf("|       6. Xoa Employee O Vi Tri Dau Danh Sach Employee Hien Tai                     |\n");
	printf("|       7. Xoa Employee O Vi Tri Cuoi Danh Sach Employee Hien Tai                    |\n");
	printf("|       8. Xoa Employee O 1 Vi Tri Ma Ban Muon                                       |\n");
	printf("|       9. Tim 1 Employee Theo So Dien Thoai ( SDT )                                 |\n");
	printf("|       10. Xuat Danh Sach Employee Di Lam Sau Ngay, Thang, Nam Ma Ban Muon Tim      |\n");
	printf("|       11. Sap Xep Danh Sach Employee Theo Alphabet (Selection Sort)                |\n");
	printf("|       12. Sap Xep Danh Sach Employee Theo Alphabet (Quick Sort)                    |\n");
	printf("|       13. Gop 2 Danh Sach Employee                                                 |\n");
	printf("|       14. Lay Danh Sach Employee Di Lam Sau Ngay Ban Muon Tim                      |\n");
	printf("|       15. Lay Thong Tin Employee Lon Tuoi Nhat                                     |\n");
	printf("|                                                                                    |\n");
	printf("|       16. Thoat Chuong Trinh                                                       |\n");
	printf("|                                                                                    |\n");
	printf("======================================================================================\n");
	printf("\nBan chon:  ");
	int user_chucnang;
	do
	{
		scanf("%d",&user_chucnang);
		if(user_chucnang>=1 && user_chucnang<=16)
		{
			break;
		}
		else
		{
			printf("\nBan vui long chon dung chuc nang cua chuong trinh ( 1 -> 16 ), moi ban chon lai:  ");
		}
	}while(true);
	return user_chucnang;
}

void Thoat_Chuong_Trinh(DoubleList &list)
{
	printf("\nGo phim \" 1 \" de den voi Menu\n\nGo phim \" 0 \" de thoat chuong trinh\n");
	int user_chon;
	printf("\nBan chon:  ");
	do
	{
		scanf("%d",&user_chon);
		if(user_chon==0)
		{
			Sleep(250);
			system("cls");
			printf("\nCam on ban da su dung chuong trinh\n");
			printf("\nChuong trinh duoc thuc hien boi:\n\nNguyen Trong Dung - 21133021\nLe Thai Duong - 21133095\n\n");
			system("pause");
			exit(0);
		}
		else if(user_chon==1)
		{
			break;
		}
		else
		{
			printf("\nBan da nhap sai, vui vong nhap \" 1 \" hoac \" 0 \", moi ban chon lai:  ");
		}
	}while(true);
	
}

void So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(DoubleList list)
{
	int n=SizeOfList(list);
	printf("\nHien tai dang co %d Employee trong danh sach\n",n);
}

void End_Chuc_Nang(DoubleList &list)
{
	printf("\n\n---------------------\nTask Completed!\n");
	Thoat_Chuong_Trinh(list);
}

void Active_Program()
{
	DoubleList list1;
	Initialize_List(list1);
	printf("Chao mung den voi Chuong Trinh Quan Ly Nhan Vien!\n");
	Thoat_Chuong_Trinh(list1);
	int count_case1=0;
	Employee data;
	int vitri;
	while(true)
	{
		int user_chucnang = Design_Menu();
		switch(user_chucnang)
		{
			case 1:
				Sleep(250);
				system("cls");
				printf("\n1. Nhap Danh Sach Employee\n");
				if(count_case1!=0)
				{
					printf("\nKhong the nhap them 1 danh sach moi, vui long chon 3.  4.  5.  13.  de tao them Employee trong danh sach!\n");
					Thoat_Chuong_Trinh(list1);
				}
				else
				{
					Nhap_Danh_Sach_Employee(list1);
					count_case1=1;
					End_Chuc_Nang(list1);
				}
				break;
			case 2:
				Sleep(250);
				system("cls");
				printf("\n2. Xuat Danh Sach Employee Hien Tai\n");
				Print_List(list1);
				End_Chuc_Nang(list1);
				break;
			case 3:
				Sleep(250);
				system("cls");
				printf("\n3. Chen Them Employee Vao Dau Danh Sach Employee Hien Tai\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				printf("\nNhap thong tin Employee muon them vao dau danh sach:\n");
				Nhap_Employee(data);
				Insert_First(list1,data);
				End_Chuc_Nang(list1);
				break;
			case 4:
				Sleep(250);
				system("cls");
				printf("\n4. Chen Them Employee Vao Cuoi Danh Sach Employee Hien Tai\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				printf("\nNhap thong tin Employee muon them vao cuoi danh sach:\n");
				Nhap_Employee(data);
				Insert_Last(list1,data);
				End_Chuc_Nang(list1);
				break;
			case 5:
				Sleep(250);
				system("cls");
				printf("\n5. Chen Them Employee Vao Sau 1 Vi Tri Ma Ban Muon\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(list1.pHead==NULL)
				{
					printf("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay!\n");
				}
				else
				{
					printf("\nNhap thong tin Employee muon them vao sau 1 vi tri cu the trong danh sach:\n");
					Nhap_Employee(data);
					Insert_Mid(list1,vitri,data);
				}
				End_Chuc_Nang(list1);
				break;
			case 6:
				Sleep(250);
				system("cls");
				printf("\n6. Xoa Employee O Vi Tri Dau Danh Sach Employee Hien Tai\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(SizeOfList(list1)>=2)
				{
					printf("\nStarting delete Employee o dau danh sach ...\n");
					Remove_First(list1);
					Sleep(1500);
				}
				else
				{
					printf("\nSo luong Employee trong danh sach < 2 nen khong the thuc hien chuc nang nay\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 7:
				Sleep(250);
				system("cls");
				printf("\n7. Xoa Employee O Vi Tri Cuoi Danh Sach Employee Hien Tai\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(SizeOfList(list1)>=2)
				{
					printf("\nStarting delete Employee o cuoi danh sach ...\n");
					Remove_Last(list1);
					Sleep(1500);
				}
				else
				{
					printf("\nSo luong Employee trong danh sach < 2 nen khong the thuc hien chuc nang nay\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 8:
				Sleep(250);
				system("cls");
				printf("\n8. Xoa Employee O 1 Vi Tri Ma Ban Muon\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(list1.pHead==NULL)
				{
					printf("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay!\n");
				}
				else
				{
					Remove_Mid(list1,vitri);
					printf("\nStarting delete Employee o vi tri thu %d trong danh sach ...\n",vitri+1);
					Sleep(1500);
				}
				End_Chuc_Nang(list1);
				break;
			case 9:
				Sleep(250);
				system("cls");
				printf("\n9. Tim 1 Employee Theo So Dien Thoai ( SDT )\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				Tim_Kiem_Employee_Theo_SDT(list1,data);
				End_Chuc_Nang(list1);
				break;
			case 10:
				Sleep(250);
				system("cls");
				printf("\n10. Xuat Danh Sach Employee Di Lam Sau Ngay, Thang, Nam Ma Ban Muon Tim\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				Danh_Sach_Employee_Vao_Lam_Sau_Ngay_Cho_Truoc(list1,data);
				End_Chuc_Nang(list1);
				break;
			case 11:
				Sleep(250);
				system("cls");
				printf("\n11. Sap Xep Danh Sach Employee Theo Alphabet (Selection Sort) \n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(SizeOfList(list1)>=2)
				{
					printf("\nStarting Selection Sort danh sach Employee theo Alphabet ...\n");
					Sort_List_Selection_Sort(list1);
					Sleep(1500);
				}
				else
				{
					printf("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach < 2\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 12:
				Sleep(250);
				system("cls");
				printf("\n12. Sap Xep Danh Sach Employee Theo Alphabet (Quick Sort)\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(SizeOfList(list1)>=2)
				{
					printf("\nStarting Quick Sort danh sach Employee theo Alphabet ...\n",vitri);
					Sort_List_Quick_Sort(list1);
					Sleep(1500);
				}
				else
				{
					printf("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach < 2\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 13:
				Sleep(250);
				system("cls");
				printf("\n13. Gop 2 Danh Sach Employee\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(!Check_Empty_List(list1))
				{
					Merge_Two_List(list1);
				}
				else
				{
					printf("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach ban dau dang rong\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 14:
				Sleep(250);
				system("cls");
				printf("\n14. Lay Danh Sach Employee Di Lam Sau Ngay Ban Muon Tim\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(!Check_Empty_List(list1))
				{
					Xoa_Employee_Di_Lam_Truoc_Ngay_Duoc_Nhap(list1,data);
					Sleep(1500);
				}
				else
				{
					printf("\nDanh sach ban dau dang rong nen khong the thuc hien chuc nang nay\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 15:
				Sleep(250);
				system("cls");
				printf("\n15. Lay Thong Tin Employee Lon Tuoi Nhat\n");
				So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
				if(SizeOfList(list1)>=2)
				{
					printf("\nThong tin cua Employee lon tuoi nhat trong danh sach la:\n");
					Node *Tuoi_MAX = Employee_Lon_Tuoi_Nhat(list1);
					Xuat_Employee(Tuoi_MAX->data);
				}
				else
				{
					printf("\nSo luong Employee trong danh sach hien tai < 2 nen khong the thuc hien chuc nang nay\n");
				}
				End_Chuc_Nang(list1);
				break;
			case 16:
				Sleep(250);
				system("cls");
				printf("\nBan co thuc su muon thoat?\n");
				Thoat_Chuong_Trinh(list1);
				break;
			default:
				printf("\nBan vui long nhap dung chuc nang cua chuong trinh de su dung\n");
				Sleep(2750);
				break;
		}
	}
}
