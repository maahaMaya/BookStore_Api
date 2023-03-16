using CloudinaryDotNet;
using CommonLayer.Models.AdminModel;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RepositoryLayer.Service
{
    public class BookRl : I_BookRl
    {
        private readonly string _connectionString;
        SqlConnection sqlConnection;
        private static readonly string roleCheckForAddBook = "Admin";
        IConfiguration iconfiguration; 

        private readonly string CloudName;
        private readonly string ApiKey;
        private readonly string ApiSecret;
        public BookRl(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;

            CloudName = iconfiguration.GetSection("CloudinarySettings").GetSection("CloudName").Value;
            ApiKey = iconfiguration.GetSection("CloudinarySettings").GetSection("APIKey").Value;
            ApiSecret = iconfiguration.GetSection("CloudinarySettings").GetSection("APISecret").Value;
        }

        /// <summary>
        /// add a new book only by admin role
        /// </summary>
        /// <param name="addNewBook"></param>
        /// <param name="premissionToAddBook"></param>
        /// <returns></returns>
        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook)
        {
            sqlConnection = new SqlConnection(_connectionString);
            try
            {
                if (premissionToAddBook == roleCheckForAddBook)
                {
                    SqlCommand cmd = new SqlCommand("spAddNewBook", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@book_title", addNewBook.book_title);
                    cmd.Parameters.AddWithValue("@book_author", addNewBook.book_author);
                    cmd.Parameters.AddWithValue("@book_rating", addNewBook.book_rating);
                    cmd.Parameters.AddWithValue("@book_total_rating", addNewBook.book_total_rating);
                    cmd.Parameters.AddWithValue("@book_actual_price", addNewBook.book_actual_price);
                    cmd.Parameters.AddWithValue("@book_discount_price", addNewBook.book_discount_price);
                    cmd.Parameters.AddWithValue("@book_description", addNewBook.book_description);
                    cmd.Parameters.AddWithValue("@book_stock", addNewBook.book_stock);
                    cmd.Parameters.AddWithValue("@book_image", addNewBook.book_image);

                    this.sqlConnection.Open();
                    int databaseUpdateValue = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (databaseUpdateValue >= 1)
                    {
                        return addNewBook;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Find book on the basis of bookId
        /// </summary>
        ///  <param name="getBookById"></param>
        /// <returns>matched book details</returns>
        public GetBook getBookById(GetBookById getBookById)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetBookByBookId", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@book_id", getBookById.book_id);

                    sqlConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if(!rdr.HasRows) 
                    {
                        return null;
                    }
                    while (rdr.Read())
                    {
                        GetBook getBook = new GetBook();

                        getBook.book_id = Convert.ToInt32(rdr["book_id"]);
                        getBook.book_title = rdr["book_title"].ToString();
                        getBook.book_author = rdr["book_author"].ToString();
                        getBook.book_rating = Convert.ToSingle(rdr["book_rating"]);
                        getBook.book_total_rating = Convert.ToInt32(rdr["book_total_rating"]);
                        getBook.book_actual_price = Convert.ToInt32(rdr["book_actual_price"]);
                        getBook.book_discount_price = Convert.ToInt32(rdr["book_discount_price"]);
                        getBook.book_description = rdr["book_description"].ToString();
                        getBook.book_stock = Convert.ToInt32(rdr["book_stock"]);
                        getBook.book_image = rdr["book_image"].ToString();

                        return getBook;
                    }
                    sqlConnection.Close();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// get all books in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetBook> getAllBook()
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                List<GetBook> getBookList = new List<GetBook>();
                SqlCommand cmd = new SqlCommand("spGetAllBook", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                while (rdr.Read())
                {
                    GetBook getBook = new GetBook();

                    getBook.book_id = Convert.ToInt32(rdr["book_id"]);
                    getBook.book_title = rdr["book_title"].ToString();
                    getBook.book_author = rdr["book_author"].ToString();
                    getBook.book_rating = Convert.ToSingle(rdr["book_rating"]);
                    getBook.book_total_rating = Convert.ToInt32(rdr["book_total_rating"]);
                    getBook.book_actual_price = Convert.ToInt32(rdr["book_actual_price"]);
                    getBook.book_discount_price = Convert.ToInt32(rdr["book_discount_price"]);
                    getBook.book_description = rdr["book_description"].ToString();
                    getBook.book_stock = Convert.ToInt32(rdr["book_stock"]);
                    getBook.book_image = rdr["book_image"].ToString();

                    getBookList.Add(getBook);
                }
                sqlConnection.Close();
                return getBookList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        } 

        public UpdateBook updateBookByAdmin(UpdateBook updateBook)
        {
            sqlConnection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateBook", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@book_id", updateBook.book_id);
                cmd.Parameters.AddWithValue("@book_title", updateBook.book_title);
                cmd.Parameters.AddWithValue("@book_author", updateBook.book_author);
                cmd.Parameters.AddWithValue("@book_rating", updateBook.book_rating);
                cmd.Parameters.AddWithValue("@book_total_rating", updateBook.book_total_rating);
                cmd.Parameters.AddWithValue("@book_actual_price", updateBook.book_actual_price);
                cmd.Parameters.AddWithValue("@book_discount_price", updateBook.book_discount_price);
                cmd.Parameters.AddWithValue("@book_description", updateBook.book_description);
                cmd.Parameters.AddWithValue("@book_stock", updateBook.book_stock);
                cmd.Parameters.AddWithValue("@book_image", updateBook.book_image);

                this.sqlConnection.Open();
                int databaseUpdateValue = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return updateBook;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }


        /// <summary>
        /// update the image in database
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="getBookById"></param>
        /// <returns></returns>
        public bool BookImageUpdate(UpdateBookImage updateBookImage)
        {
            try
            {
                string uploadImagePath = ImageUploadOnCloudinary(updateBookImage.ImgFile);

                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateBookImage", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@book_id", updateBookImage.book_id);
                cmd.Parameters.AddWithValue("@book_image", uploadImagePath);

                sqlConnection.Open();
                int databaseUpdateValue = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// take filePath of image and give the url of image
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public string ImageUploadOnCloudinary(IFormFile imageFile)
        {
            try
            {
                Account account = new Account(CloudName, ApiKey, ApiSecret);

                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),

                };

                var uploadResult = cloudinary.Upload(uploadParams);
                string imagePath = uploadResult.Url.ToString();
                return imagePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
