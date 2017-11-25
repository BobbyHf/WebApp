using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace BHIP.Model
{
    public class MenuViewModel
    {
        public IQueryable<MenuView> menuView { get; set; }

        #region Contains
        //public bool Contains(T data)
        //{
        //    // search the tree for a node that contains data
        //    BinaryTreeNode<T> current = root;
        //    int result;
        //    while (current != null)
        //    {
        //        result = comparer.Compare(current.Value, data);
        //        if (result == 0)
        //            // we found data
        //            return true;
        //        else if (result > 0)
        //            // current.Value > data, search current's left subtree
        //            current = current.Left;
        //        else if (result < 0)
        //            // current.Value < data, search current's right subtree
        //            current = current.Right;
        //    }

        //    return false;       // didn't find data
        //} 
        #endregion

        #region Add
        //public virtual void Add(T data)
        //{
        //    // create a new Node instance
        //    BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
        //    int result;

        //    // now, insert n into the tree
        //    // trace down the tree until we hit a NULL
        //    BinaryTreeNode<T> current = root, parent = null;
        //    while (current != null)
        //    {
        //        result = comparer.Compare(current.Value, data);
        //        if (result == 0)
        //            // they are equal - attempting to enter a duplicate - do nothing
        //            return;
        //        else if (result > 0)
        //        {
        //            // current.Value > data, must add n to current's left subtree
        //            parent = current;
        //            current = current.Left;
        //        }
        //        else if (result < 0)
        //        {
        //            // current.Value < data, must add n to current's right subtree
        //            parent = current;
        //            current = current.Right;
        //        }
        //    } 

        // We're ready to add the node!
        //    count++;
        //    if (parent == null)
        //        // the tree was empty, make n the root
        //        root = n;
        //    else
        //    {
        //        result = comparer.Compare(parent.Value, data);
        //        if (result > 0)
        //            // parent.Value > data, therefore n must be added to the left subtree
        //            parent.Left = n;
        //        else
        //            // parent.Value < data, therefore n must be added to the right subtree
        //            parent.Right = n;
        //    }
        //}
        #endregion

        #region Remove
        //public bool Remove(T data)
        //{
        //    // first make sure there exist some items in this tree
        //    if (root == null)
        //        return false;       // no items to remove

        //    // Now, try to find data in the tree
        //    BinaryTreeNode<T> current = root, parent = null;
        //    int result = comparer.Compare(current.Value, data);
        //    while (result != 0)
        //    {
        //        if (result > 0)
        //        {
        //            // current.Value > data, if data exists it's in the left subtree
        //            parent = current;
        //            current = current.Left;
        //        }
        //        else if (result < 0)
        //        {
        //            // current.Value < data, if data exists it's in the right subtree
        //            parent = current;
        //            current = current.Right;
        //        }

        //        // If current == null, then we didn't find the item to remove
        //        if (current == null)
        //            return false;
        //        else
        //            result = comparer.Compare(current.Value, data);
        //    }

        //    // At this point, we've found the node to remove
        //    count--;

        //    // We now need to "rethread" the tree
        //    // CASE 1: If current has no right child, then current's left child becomes
        //    //         the node pointed to by the parent
        //    if (current.Right == null)
        //    {
        //        if (parent == null)
        //            root = current.Left;
        //        else
        //        {
        //            result = comparer.Compare(parent.Value, current.Value);
        //            if (result > 0)
        //                // parent.Value > current.Value, so make current's left child a left child of parent
        //                parent.Left = current.Left;
        //            else if (result < 0)
        //                // parent.Value < current.Value, so make current's left child a right child of parent
        //                parent.Right = current.Left;
        //        }
        //    }
        //    // CASE 2: If current's right child has no left child, then current's right child
        //    //         replaces current in the tree
        //    else if (current.Right.Left == null)
        //    {
        //        current.Right.Left = current.Left;

        //        if (parent == null)
        //            root = current.Right;
        //        else
        //        {
        //            result = comparer.Compare(parent.Value, current.Value);
        //            if (result > 0)
        //                // parent.Value > current.Value, so make current's right child a left child of parent
        //                parent.Left = current.Right;
        //            else if (result < 0)
        //                // parent.Value < current.Value, so make current's right child a right child of parent
        //                parent.Right = current.Right;
        //        }
        //    }
        //    // CASE 3: If current's right child has a left child, replace current with current's
        //    //          right child's left-most descendent
        //    else
        //    {
        //        // We first need to find the right node's left-most child
        //        BinaryTreeNode<T> leftmost = current.Right.Left, lmParent = current.Right;
        //        while (leftmost.Left != null)
        //        {
        //            lmParent = leftmost;
        //            leftmost = leftmost.Left;
        //        }

        //        // the parent's left subtree becomes the leftmost's right subtree
        //        lmParent.Left = leftmost.Right;

        //        // assign leftmost's left and right to current's left and right children
        //        leftmost.Left = current.Left;
        //        leftmost.Right = current.Right;

        //        if (parent == null)
        //            root = leftmost;
        //        else
        //        {
        //            result = comparer.Compare(parent.Value, current.Value);
        //            if (result > 0)
        //                // parent.Value > current.Value, so make leftmost a left child of parent
        //                parent.Left = leftmost;
        //            else if (result < 0)
        //                // parent.Value < current.Value, so make leftmost a right child of parent
        //                parent.Right = leftmost;
        //        }
        //    }

        //    return true;
        //} 
        #endregion

        public IQueryable<MenuView> DisplayMenu(int parentID)
        {
            IQueryable<MenuView> dataDescendants = null;
            string userId = HttpContext.Current.User.Identity.GetUserId();

            int levelCount = (from menu in ContextPerRequest.CurrentData.Menus
                              join shellMenuRole in ContextPerRequest.CurrentData.MenuRoles on menu.MenuID equals shellMenuRole.MenuId
                              where menu.Level == 1 &&
                              (from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == shellMenuRole.RoleId) select user.Id).FirstOrDefault().Contains(userId)
                              //orderby allDesc.LeftNode ascending
                              select menu.MenuID).Distinct().Count();


            var dataTree = (from tree in ContextPerRequest.CurrentData.Menus
                            where tree.ParentID == parentID
                            select new List<int>
                            {
                                tree.LeftNode,
                                tree.RightNode
                            }).ToArray();


            if (dataTree.Count() > 0)
            {
                List<int> rightStack = new List<int>();
                int leftTempNode = dataTree[0][0];
                int rightTempNode = dataTree[0][1];

                var uniqueList = (from allDesc in ContextPerRequest.CurrentData.Menus
                                  join shellMenuRole in ContextPerRequest.CurrentData.MenuRoles on allDesc.MenuID equals shellMenuRole.MenuId
                                  where allDesc.LeftNode >= leftTempNode && allDesc.RightNode <= rightTempNode
                                  && (from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == shellMenuRole.RoleId) select user.Id).FirstOrDefault().Contains(userId)
                                  //orderby allDesc.LeftNode ascending
                                  select allDesc.MenuID).Distinct();

                dataDescendants = (from allDesc in ContextPerRequest.CurrentData.Menus
                                   where uniqueList.Contains(allDesc.MenuID)
                                   orderby allDesc.LeftNode ascending
                                   select new MenuView
                                   {
                                       LeftNode = allDesc.LeftNode,
                                       Level = allDesc.Level,
                                       Link = allDesc.Link,
                                       MenuID = allDesc.MenuID,
                                       Parent = allDesc.ParentID,
                                       RightNode = allDesc.RightNode,
                                       Title = allDesc.Title,
                                       LevelCount = levelCount
                                   });
            }

            return dataDescendants;
        }

        public IQueryable<MenuView> DisplayAdminMenu(int parentID)
        {
            IQueryable<MenuView> dataDescendants = null;
            string userId = HttpContext.Current.User.Identity.GetUserId();


            int levelCount = (from menu in ContextPerRequest.CurrentData.Menus
                              //join trustMenuRole in ContextPerRequest.Current.TrustMenuRoles on menu.MenuID equals trustMenuRole.MenuId
                              where menu.Level == 1
                              select menu).Count();

            var dataTree = (from tree in ContextPerRequest.CurrentData.Menus
                            where tree.ParentID == parentID
                            select new List<int>
                            {
                                tree.LeftNode,
                                tree.RightNode
                            }).ToArray();


            if (dataTree.Count() > 0)
            {
                List<int> rightStack = new List<int>();
                int leftTempNode = dataTree[0][0];
                int rightTempNode = dataTree[0][1];

                dataDescendants = (from allDesc in ContextPerRequest.CurrentData.Menus
                                   //join trustMenuRole in ContextPerRequest.Current.TrustMenuRoles on allDesc.MenuID equals trustMenuRole.MenuId
                                   where allDesc.LeftNode >= leftTempNode && allDesc.RightNode <= rightTempNode
                                   orderby allDesc.LeftNode ascending
                                   select new MenuView
                                   {
                                       LeftNode = allDesc.LeftNode,
                                       Level = allDesc.Level,
                                       Link = allDesc.Link,
                                       MenuID = allDesc.MenuID,
                                       Parent = allDesc.ParentID,
                                       RightNode = allDesc.RightNode,
                                       Title = allDesc.Title,
                                       LevelCount = levelCount
                                   });
            }


            return dataDescendants;
        }
        public IQueryable<MenuView> display_tree(int parentID)
        {
            List<MenuView> menuItems = new List<MenuView>();
            IQueryable<MenuView> dataDescendants = null;

            var dataTree = (from tree in ContextPerRequest.CurrentData.Menus
                            where tree.ParentID == parentID
                            select new List<int>
                            {
                                tree.LeftNode,
                                tree.RightNode
                            }).ToArray();
            if (dataTree.Count() > 0)
            {
                List<int> rightStack = new List<int>();
                int leftTempNode = dataTree[0][0];
                int rightTempNode = dataTree[0][1];
                dataDescendants = (from allDesc in ContextPerRequest.CurrentData.Menus
                                   where allDesc.LeftNode >= leftTempNode && allDesc.RightNode <= rightTempNode
                                   orderby allDesc.LeftNode ascending
                                   select new MenuView
                                   {
                                       LeftNode = allDesc.LeftNode,
                                       Level = allDesc.Level,
                                       Link = allDesc.Link,
                                       MenuID = allDesc.MenuID,
                                       Parent = allDesc.ParentID,
                                       RightNode = allDesc.RightNode,
                                       Title = allDesc.Title
                                   });

                foreach (var item in dataDescendants)
                {
                    if (rightStack.Count > 0)
                    {
                        int i = 0;
                        while (rightStack[rightStack.Count - 1] < item.RightNode)
                        {
                            rightStack.RemoveAt(i);
                            i++;
                        }
                    }
                    // display tree 
                    menuItems.Add(item);

                    rightStack.Add(item.RightNode);
                }
            }

            return dataDescendants;
        }

        public int rebuild_tree(int menuID, int leftNode)
        {
            int rightNode = leftNode + 1;
            var dataChildren = (from children in ContextPerRequest.CurrentData.Menus
                                where children.ParentID == menuID
                                select new MenuView
                                {
                                    LeftNode = children.LeftNode,
                                    MenuID = children.MenuID,
                                    Parent = children.ParentID,
                                    RightNode = children.RightNode,
                                    Title = children.Title
                                });

            foreach (var item in dataChildren)
            {
                // recursive execution of this function for each
                // child of this node.
                // rightNode is the current right value, which is 
                //incremented by the rebuild_tree function
                rightNode = rebuild_tree(item.MenuID, rightNode);
            }

            var dataRight = (from rightChild in ContextPerRequest.CurrentData.Menus
                             where rightChild.MenuID == menuID
                             select rightChild).FirstOrDefault();

            dataRight.LeftNode = leftNode;
            dataRight.RightNode = rightNode;

            ContextPerRequest.CurrentData.SaveChanges();

            return rightNode + 1;
        }

        public int InsertMenuItem(int parentID, string menuTitle, string link)
        {
            Menu menu;
            int leftNode = 0;
            int rightNode = 0;
            int rightParent = 0;
            int rightParentOrig = 0;
            int leftParentOrig = 0;
            int level = 0;
            int returnId = 0;

            if (parentID == 0)
            {
                leftNode = 1;
                rightNode = 2;
                level = 0;
            }
            else
            {
                menu = (from menus in ContextPerRequest.CurrentData.Menus
                        where menus.MenuID == parentID
                        select menus).FirstOrDefault();
                if (menu != null)
                {
                    rightParentOrig = menu.RightNode;
                    leftParentOrig = menu.LeftNode;
                    leftNode = menu.RightNode;
                    rightNode = menu.RightNode + 1;
                    level = menu.Level + 1;
                    rightParent = rightNode + 1;
                }
            }
            var dataLeftRight = (from menus in ContextPerRequest.CurrentData.Menus
                                 where menus.LeftNode >= leftNode
                                 select menus);
            foreach (var item in dataLeftRight)
            {
                item.RightNode = item.RightNode + 2;
                item.LeftNode = item.LeftNode + 2;
            }

            ContextPerRequest.CurrentData.SaveChanges();

            var dataRight = (from menus in ContextPerRequest.CurrentData.Menus
                             where menus.LeftNode < leftParentOrig && menus.RightNode > rightParentOrig
                             select menus);
            foreach (var item in dataRight)
            {
                item.RightNode = item.RightNode + 2;
            }
            ContextPerRequest.CurrentData.SaveChanges();

            Menu shellMenu = new Menu
            {
                LeftNode = leftNode,
                Link = link ?? string.Empty,
                ParentID = parentID,
                RightNode = rightNode,
                Title = menuTitle,
                Level = level
            };
            ContextPerRequest.CurrentData.Menus.Add(shellMenu);
            ContextPerRequest.CurrentData.SaveChanges();
            returnId = shellMenu.MenuID;

            if (rightParent != null)
            {
                var dataRightParent = (from menus in ContextPerRequest.CurrentData.Menus
                                       where menus.MenuID == parentID
                                       select menus);
                foreach (var item in dataRightParent)
                {
                    item.RightNode = rightParent;
                }
                ContextPerRequest.CurrentData.SaveChanges();
            }

            return returnId;
        }
        public void DeleteMenuItem(int menuID)
        {
            var dataMenu = (from menus in ContextPerRequest.CurrentData.Menus
                            where menus.MenuID == menuID
                            select menus).FirstOrDefault();

            if (dataMenu != null)
            {
                // delete the existing menu item.
                var dataDeleteMenu = (from menus in ContextPerRequest.CurrentData.Menus
                                      where menus.MenuID == menuID
                                      select menus).FirstOrDefault();
                ContextPerRequest.CurrentData.Menus.Remove(dataDeleteMenu);
                ContextPerRequest.CurrentData.SaveChanges();

                // update the left and right nodes.
                var dataUpdateMenu = (from menus in ContextPerRequest.CurrentData.Menus
                                      where menus.LeftNode >= dataMenu.LeftNode
                                      select menus);

                foreach (var item in dataUpdateMenu)
                {
                    item.LeftNode = item.LeftNode - 2;
                    item.RightNode = item.RightNode - 2;
                }

                ContextPerRequest.CurrentData.SaveChanges();

                var dataUpdateLeftRight = (from menus in ContextPerRequest.CurrentData.Menus
                                           where menus.LeftNode < dataMenu.LeftNode && menus.RightNode > dataMenu.RightNode
                                           select menus);
                foreach (var item in dataUpdateLeftRight)
                {
                    item.RightNode = item.RightNode - 2;
                }

                ContextPerRequest.CurrentData.SaveChanges();

            }
        }

        public void SaveOrder(string menuOrder)
        {
            IList<MenuSort> menuList = JsonConvert.DeserializeObject<IList<MenuSort>>(menuOrder);

            foreach (var item in menuList)
            {
                SaveMenu(item);
            }
        }

        public void SaveMenu(MenuSort menuSort)
        {
            var dataMenu = (from menus in ContextPerRequest.CurrentData.Menus
                            where menus.MenuID == menuSort.item_id
                            select menus).FirstOrDefault();
            dataMenu.LeftNode = menuSort.left;
            dataMenu.RightNode = menuSort.right;
            dataMenu.Level = menuSort.depth;
            dataMenu.ParentID = menuSort.parent_id ?? 0;

            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void SaveEditMenu(MenuView menu)
        {
            var dataMenu = (from menus in ContextPerRequest.CurrentData.Menus
                            where menus.MenuID == menu.MenuID
                            select menus).FirstOrDefault();
            dataMenu.Title = menu.Title;
            dataMenu.Link = menu.Link;
            //try{
            ContextPerRequest.CurrentData.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
        }

        public MenuView GetMenu(int id)
        {
            MenuView dataMenu = (from menus in ContextPerRequest.CurrentData.Menus
                                 where menus.MenuID == id
                                 select new MenuView
                                 {
                                     LeftNode = menus.LeftNode,
                                     Level = menus.Level,
                                     Link = menus.Link,
                                     MenuID = menus.MenuID,
                                     Parent = menus.ParentID,
                                     RightNode = menus.RightNode,
                                     Title = menus.Title
                                 }).FirstOrDefault();

            return dataMenu;
        }

        public IEnumerable<SelectListItem> GetRoles()
        {
            IEnumerable<SelectListItem> returnValue;

            var query = (from roles in ContextPerRequest.CurrentData.AspNetRoles
                         select roles);

            returnValue = query.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id
            });

            //return new SelectList(query, "Id", "Name" );
            return returnValue;

        }
        public IEnumerable<SelectListItem> GetEditRoles(int menuId)
        {
            var menuRoles = (from menuroles in ContextPerRequest.CurrentData.MenuRoles
                             where menuroles.MenuId == menuId
                             select menuroles.RoleId).ToList();

            IEnumerable<SelectListItem> returnValue;

            var query = (from roles in ContextPerRequest.CurrentData.AspNetRoles
                         select roles);

            returnValue = query.ToList().Select(u => new SelectListItem
            {
                Selected = menuRoles.Contains(u.Id),
                Text = u.Name,
                Value = u.Id
            });

            return returnValue;
        }

        public void SaveMenuRoles(int menuId, string[] selectedRoles)
        {
            foreach (string item in selectedRoles)
            {
                MenuRole menuRole = new MenuRole
                {
                    MenuId = menuId,
                    RoleId = item
                };

                ContextPerRequest.CurrentData.MenuRoles.Add(menuRole);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void SaveEditMenuRoles(int menuId, string[] selectedRoles)
        {
            var dataDeleteMenuRoles = (from roles in ContextPerRequest.CurrentData.MenuRoles
                                       where roles.MenuId == menuId
                                       select roles);
            foreach (var item in dataDeleteMenuRoles)
            {

                ContextPerRequest.CurrentData.MenuRoles.Remove(item);
            }
            ContextPerRequest.CurrentData.SaveChanges();

            foreach (string item in selectedRoles)
            {
                MenuRole menuRole = new MenuRole
                {
                    MenuId = menuId,
                    RoleId = item
                };

                ContextPerRequest.CurrentData.MenuRoles.Add(menuRole);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
    }

    public class MenuSort
    {
        public int item_id { get; set; }
        public int? parent_id { get; set; }
        public int depth { get; set; }
        public int left { get; set; }
        public int right { get; set; }
    }

    public class MenuView
    {
        public int MenuID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public int Parent { get; set; }
        public int LeftNode { get; set; }
        public int RightNode { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }
        public int Level { get; set; }
        public int LevelCount { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }

    }

    public class Node<T>
    {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            base.Neighbors = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public virtual void Clear()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }
    }
}